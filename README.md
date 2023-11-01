# About
This repository contains a skeleton project to be used as a starting point for a take-home coding test.

It is intended for candidates applying for a .NET back-end software development role at Humanforce.

# Scenario
The task is to build a web API backend application using dotnet core. The purpose of the API is to store images and perform a few processing tasks such as converting and resizing.

The API should have 3 endpoints:

| Endpoint                 | Description |
|--------------------------|-------------|
| `POST /api/image/upload` | Accepts an image along with parameters to specify desired image format, desired dimensions, and whether to keep aspect ratio. Processes and stores the image in the database and returns a permanent unique ID for the converted image.
| `GET /api/image/get`     | Allows an image to be retrieved by ID and returned in its native format with the relevant content type (to allow embedding in a webpage). |
| `GET /api/image/info`    | Retrieves information about an image. E.g. its format, persisted size, dimensions, date/time uploaded, and any other info that may be relevant. |

As a bonus exercise, add authentication to the application using a JWT. The database should include a table to hold the pre-authenticated API callers. Use any one of the typical signing algorithms supported by the Postman application (e.g. HS256, RS256, etc.).

# Project Template
This repo contains an existing project you can use as a starting point.

In addition to the project skeleton, see also:
* ImageController.cs - This controller has stubs for the endpoints listed above. Make as many changes as you like to suit your approach (e.g. input & output types, async code, etc.)
* ImageService.cs - This class provides an example of how to use the SkiaSharp image library for converting and resizing images. Most of what you need is here already so you shouldn't have to spend time discovering how to use the library, but you will need to implement the `keepAspectRatio` parameter in the `ResizeImage` method.
* ImageUploadModel.cs - A model class that can be used to accept the incoming parameters for the `Upload` endpoint. Add more properties & annotations, adapt this model as needed.

# Unit Tests
The Visual Studio solution contains a UnitTests project. Wherever possible please add a few unit tests for your code. Segregate the tests into multiple classes to keep things organised if required.

The ControllerTests.cs file contains some example code for unit testing a file upload using `multipart/form-data`. Do not feel that you have to use this approach - the code is there purely to save you time if you choose to employ that method, since setting up a unit test to populate the `Request.Form.Files` property is slightly more complicated than other approaches.

# Before you start
There are multiple approaches when it comes to uploading binary data over HTTP (e.g. JSON with encoding, multipart/form-data, raw binary payload + url params, BSON, etc.). Choose whichever method you prefer. There is not necessarily any right or wrong way, but be prepared to talk about the pros and cons of the method that you choose.

Be aware that the SkiaSharp image library has some limitations in its default configuration. While it can read a variety of image formats, it can only encode PNG and JPEG without taking extra steps to support more formats. Please do not worry about this limitation for this exercise, it is perfectly OK to support PNG and JPEG only. Supporting a large number of formats is not the focus for this task.

You may use whichever database engine you like. EntityFrameworkCore is the preferred library for DB access, please use it if you can. In this case be sure to employ the code-first approach and include your DbContext and model classes in the repo. Regardless of what you use, make sure you include all database related code & scripts that are required to deploy your finished project.

This skeleton project is provided just to help get you started. You do not have to conform to any styles or patterns used here, we want to see what you believe is best. Feel free to make as many changes as you like to show-case your knowledge. If you want to throw away this template and start from scratch that's totally fine too!

If you have any questions please don't hestitate to reach out.

Good luck!
