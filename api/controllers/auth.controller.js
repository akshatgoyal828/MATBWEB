var auth_service = require("../services/auth/auth.services");
const { responseData } = require("../helpers/responseData");

module.exports = {
  /**
   * Update data on fireStore
   *
   * @method post
   *
   * @param {*} req
   * @param {*} res
   * @returns
   */
  fireStore: async (req, res) => {
    try {
      await auth_service.fireStore(req, res);
    } catch (err) {
      var msg = err.message || "SOMETHING_WENT_WRONG";
      return res.status(422).json(responseData(msg, {}, 422));
    }
  },
  /**
   * Fcm User login
   *
   * @method post
   *
   * @param {*} req
   * @param {*} res
   * @returns
   *
   * {"email":"asugarmd.ph@gmail.com","password":"Test@123"}
   */
  fcmLogin: async (req, res) => {
    try {
      await auth_service.fcmLogin(req, res);
    } catch (err) {
      var msg = err.message || "SOMETHING_WENT_WRONG";
      return res.status(422).json(responseData(msg, {}, 422));
    }
  },
};
