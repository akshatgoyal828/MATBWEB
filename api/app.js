require("dotenv").config({ path: `.env.${process.env.NODE_ENV}` });
var express = require("express");
var path = require("path");
var logger = require("morgan");
var bodyParser = require("body-parser");
var fileUpload = require("express-fileupload");
var cors = require("cors");
require("./config/database");

var indexRouter = require("./routes/index");
var authRouter = require("./routes/auth");

var app = express();

var corsOption = {
  methods: "GET,HEAD,PUT,PATCH,POST,DELETE",
  credentials: true,
  exposedHeaders: ["x-access-token"],
};

app.use(cors(corsOption));
app.use(fileUpload());
// view engine setup
app.set("views", path.join(__dirname, "views"));
app.set("view engine", "ejs");
app.use(logger("dev"));
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: true }));
app.use(express.static("public"));
app.use(express.static(path.join(__dirname, "public")));

app.use("/v1/", indexRouter);
app.use("/v1/auth", authRouter);
app.use(function (req, res) {
  res.status(404).json({
    status: 404,
    message: "Sorry can't find that!",
    data: {},
  });
});
app.use(function (err, req, res, next) {
  res.locals.message = err.message;
  res.locals.error = req.app.get("env") === "development" ? err : {};
  res.json({
    status: err.status,
    message: err.message,
    data: {},
  });
  next();
});

module.exports = app;
