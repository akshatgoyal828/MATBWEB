const { validationResult } = require("express-validator");
const { responseData } = require("./responseData");
const config = require("../config/config");
var moment = require("moment");
const _ = require("lodash");
var path = require("path");
const fs = require("fs");
const Resize = require("./Resize");
const nodemailer = require("nodemailer");
const Notification = require("../models/Notification");
const email_service = require("../services/email/email.services");
let transporter = nodemailer.createTransport(config.NodeMailertansport);

module.exports = {
  validatorMiddleware: (req, res, next) => {
    const errors = validationResult(req);
    if (!errors.isEmpty()) {
      return res.status(422).json(responseData(errors.errors[0].msg, {}, 422));
    } else {
      next();
    }
  },
  sendNotification: async (request) => {
    const { user, message, action, title, isMail } = request;

    /**
     * Save notification
     */

    var notification = new Notification();
    notification.title = title;
    notification.description = message;
    notification.action = action;
    notification.user_id = user._id;
    notification.save();

    /**
     * Send email
     */
    if (isMail) {
      var options = await email_service.getEmailTemplateBySlug("notification");
      options.description = _.replace(
        options.description,
        "[FirstName]",
        user.first_name
      );
      options.description = _.replace(
        options.description,
        "[LastName]",
        user.last_name
      );
      options.description = _.replace(options.description, "[ACTION]", message);
      options.toEmail = user.email;
      let sendObj = {
        from: `${process.env.APP_NAME} <${process.env.fromEmail}>`,
        to: options.toEmail,
        subject: options.subject,
        html: options.description,
      };
      await transporter.sendMail(sendObj);
    }
    return true;
  },
  sendMail: async (option) => {
    let sendObj = {
      from: `${process.env.APP_NAME} <${process.env.fromEmail}>`,
      to: option.toEmail,
      subject: option.subject,
      html: option.description,
    };
    return await transporter.sendMail(sendObj);
  },
  sendMailAttachments: async (option) => {
    let sendObj = {
      from: `${process.env.APP_NAME} <${process.env.fromEmail}>`,
      to: option.toEmail,
      subject: option.subject,
      html: option.description,
      attachments: option.attachments,
    };
    return await transporter.sendMail(sendObj);
  },
  generateOTP: () => {
    return Math.floor(1000 + Math.random() * 9000); // 4 Digit OTP
  },
  ucfirst: (name) => {
    const title = name.charAt(0).toUpperCase() + name.slice(1);
    return title;
  },
  date: (date, format = "DD/MM/YYYY hh:mm A") => {
    return moment(date).format(format);
  },
  saveFile: async (fileObj, destination_folder, unlink) => {
    var base_path = path.join(__dirname + "/../public/");
    var new_path = path.join(
      __dirname + "/../public/" + destination_folder + "/"
    );
    if (!fs.existsSync(base_path)) {
      fs.mkdirSync(base_path, 755);
    }
    //fs.mkdirSync(new_path, 755);
    if (!fs.existsSync(new_path)) {
      fs.mkdir(
        path.join(__dirname + "/../public", destination_folder),
        (err) => {
          if (err) {
            return console.error(err);
          }
        }
      );
    }
    //Unlink Previous image
    if (unlink != undefined && unlink != "") {
      old_filename = unlink.split(destination_folder + "/");
      if (fs.existsSync(new_path + "/" + unlink)) {
        fs.unlinkSync(new_path + "/" + unlink);
      }
    }
    ///Upload new image
    if (typeof fileObj == "object" && fileObj.name != "") {
      let extensions = fileObj.name.split(".").pop();
      let file_name = moment() + "." + extensions;
      await fileObj.mv(new_path + "/" + file_name);
      return file_name;
    }
  },
  deleteOneFile: async (destination_folder, unlink) => {
    var new_path = path.join(
      __dirname + "/../public/" + destination_folder + "/"
    );
    if (unlink != undefined && unlink != "") {
      old_filename = unlink.split(destination_folder + "/");
      if (fs.existsSync(new_path + "/" + unlink)) {
        fs.unlinkSync(new_path + "/" + unlink);
      }
    }
    return true;
  },
  saveThumbFile: async (
    fileObj,
    destination_folder,
    unlink,
    fileName,
    height,
    width,
    THUMB
  ) => {
    var base_path = path.join(__dirname + "/../public/");
    var new_path = path.join(
      __dirname + "/../public/" + destination_folder + "/" + "thumb/"
    );
    if (!fs.existsSync(base_path)) {
      fs.mkdirSync(base_path, 755);
    }
    if (!fs.existsSync(new_path)) {
      fs.mkdirSync(new_path, 755);
    }
    if (!fs.existsSync(new_path)) {
      fs.mkdir(
        path.join(__dirname + "/../public", destination_folder + "/thumb/"),
        (err) => {
          if (err) {
            return console.error(err);
          }
        }
      );
    }
    //Unlink Previous image
    if (unlink != undefined && unlink != "") {
      old_filename = unlink.split(destination_folder + "/thumb/");
      if (fs.existsSync(new_path + "/" + unlink)) {
        fs.unlinkSync(new_path + "/" + unlink);
      }
    }
    ///Upload new image
    if (typeof fileObj == "object" && fileObj.name != "") {
      let file_name = fileName;
      const fileUploadResize = new Resize(THUMB, height, width);
      await fileUploadResize.save(fileObj.data, file_name);
    }
  },
  imageURL: async (image, PATH, IMAGE_PATH) => {
    const path = PATH + "/" + image;
    if (fs.existsSync(path)) {
      return process.env.API_PATH + IMAGE_PATH + "/" + image;
    } else {
      return process.env.API_PATH + config.DEFAULT_IMAGE;
    }
  },
};
