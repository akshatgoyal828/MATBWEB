var mongoose = require("mongoose");
const Unique = require("mongoose-beautiful-unique-validation");
const mongoosePaginate = require("mongoose-paginate-v2");
var Schema = mongoose.Schema;

function ucFirst(v) {
  return v[0].toUpperCase() + v.substring(1);
}

var fcmUser = new Schema(
  {
    first_name: { type: String, get: ucFirst, required: true },
    last_name: { type: String, get: ucFirst, required: true },
    email: {
      type: String,
      required: true,
      unique: "EMAIL_NUMBER_ALREADY_USED",
      index: true,
    },
    mobile_number: {
      type: String,
      required: false,
      unique: "MOBILE_NUMBER_ALREADY_USED",
      index: true,
    },
    password: { type: String, required: false, minlength: 6 },
    status: { type: Boolean, required: false, default: true },
  },
  {
    timestamps: { createdAt: "created_at", updatedAt: "updated_at" },
    versionKey: false,
    toObject: { getters: true, setters: true, virtuals: false },
    toJSON: { getters: true, setters: true, virtuals: false },
  }
);

fcmUser.plugin(Unique);
fcmUser.plugin(mongoosePaginate);
module.exports = mongoose.model("fcmUser", fcmUser);
