const Fcm = require("../../models/Fcm");
const { responseData } = require("../../helpers/responseData");
const bcrypt = require("bcryptjs");

const admin = require("firebase-admin");
const serviceAccount = require("../../serviceAccountKey.json");
const _ = require("lodash");
admin.initializeApp({
  credential: admin.credential.cert(serviceAccount),
});
const db = admin.firestore();
const usersDb = db.collection("users");

module.exports = {
  fireStore: async (req, res) => {
    try {
      const { email, password, first_name, last_name, mobile_number } =
        req.body;
      const passwordHash = bcrypt.hashSync(password, 10);
      var user = new Fcm();

      user.first_name = first_name;
      user.last_name = last_name;
      user.email = email;
      user.password = passwordHash;
      user.status = true;
      user.mobile_number = mobile_number;
      user.save(async function (err) {
        if (err) {
          for (prop in err.errors) {
            var str = err.errors[prop].message;
            return res.status(422).json(responseData(str, {}, 422));
          }
        } else {
          const liam = usersDb.doc(`${mobile_number}`);
          await liam.set(req.body);
          return res.json(responseData("REGISTRATION_DONE"));
        }
      });
    } catch (err) {
      return res.status(422).json(responseData(err.message, {}, 422));
    }
  },
  fcmLogin: async (req, res) => {
    try {
      const { email, password } = req.body;
      const select = {
        first_name: 1,
        password: 1,
        last_name: 1,
        email: 1,
        mobile_number: 1,
      };
      var user = {};
      user.email = email;
      Fcm.findOne(user, select, async function (err, result) {
        if (err || !result) {
          return res.status(422).json(responseData("INVALID_LOGIN", {}, 422));
        } else {
          const verified = bcrypt.compareSync(password, result.password);
          if (!verified) {
            return res.status(422).json(responseData("INVALID_LOGIN", {}, 422));
          } else {
            return res.json(responseData("ACCOUNT_LOGIN", result));
          }
        }
      });
    } catch (err) {
      return res.status(422).json(responseData(err.message, {}, 422));
    }
  },
};
