# About
This repository contains a sample project used as a basis for a take-home coding test. It is intended for candidates applying for a .NET back-end software development role at Humanforce.

# Scenario
This Web API project implements a basic online repository for image files. Images can be uploaded, resized and converted, and retrieved from the API.

# Instructions
Start by cloning this repository and ensure that you can build and run the application locally. Open the Postman collection from the `Postman` subfolder and make sure the application is working correctly.

The tasks below have an increasing level of difficulty. Complete any or all of them in any order you like according to the amount of time you have available.

Be sure to add new unit tests to the `UnitTests` project to validate any new functionality that you introduce to the application.

## Task 1 - Add KeepAspectRatio parameter
Add a new parameter to the existing `/api/image/upload` endpoint named `KeepAspectRatio`. Make changes to the code to implement this parameter as follows:

* If `KeepAspectRatio` is true the resized image should maintain its original aspect ratio after being resized.
* If `TargetWidth` is a positive non-zero number then `TargetHeight` should be ignored, and the new height is determined automatically.
* If `TargetWidth` is invalid (zero or negative) then the `TargetHeight` parameter should be used to determine the new width automatically.
* If both `TargetWidth` and `TargetHeight` are invalid then the API should return a Bad Reqest.

## Task 2 - Add Info endpoint
Add a new API endpoint called `Info` to the ImageController (GET `/api/image/info`)

The new endpoint should behave as follows:
* Lookup an image from the database by its ID.
* Return a 404 if the image ID is not valid.
* For valid images, return a JSON object containing some information about the image:
  - Original filename
  - Format
  - DateTime created (in UTC)
  - Width
  - Height
  - Stored size in bytes

## Task 3 - Prevent saving duplicate images
Add a check in the `/api/image/upload` to prevent the exact same image being saved twice.
* If an image is uploaded that is already in the database then the endpoint should return the ID of the pre-existing image. Include a new boolean field in the response called `AlreadyExists` to indicate that the duplicate was detected.
* The check for equality should be done based on the image data _after_ resizing and converting. The API should NOT reject the same image if the TargetWidth, TargetHeight or TargetFormat parameters are different to what was uploaded previously.

There are many ways this requirement can be implemented, choose any approach you like. _HINT: Consider adding a field to the Images database table to store a hash._

## Task 4 - Add encryption at rest
Implement encryption at rest in the database to protect the image data.
* Encryption should be added to the `Data` field of the Images table, other fields may remain unencrypted.
* Use the AES symmetric encryption algorithm with a 256 bit key.
* Store the key material in the appSettings.json file.
* Encryption should be transparent to the callers of the API. I.e. data should be automatically encrypted when imported via the `/upload` endpoint, and decrypted on the fly when downloaded from the `/get` endpoint.

## Task 5 - Add authentication
Add authentication to the `/api/image/upload` endpoint using a JWT.
* The JWT audience and expiry should be validated.
* Add a new column to the Images database table to hold the username of the person who uploaded the image. Return this data in the `/info` endpoint (if you have implemented it).
* Choose one of the following two approaches:
  - Integrate with an existing identity provider of your choice (e.g. Okta, Auth0, Microsoft, AWS Cognito, etc.), OR 
  - Use self-signed JWTs, storing the public key (or HMAC secret) in the appSettings.json file. Plug your private key or HMAC secret into the Postman application to generate the tokens.

# Guidelines
* Complete only the tasks that you feel confident with (they do not have to be done in order).
* Avoid spending much more than about 6 hours total.
* Be sure to complete individual tasks in full (including unit tests) before moving on to other tasks. A single fully-implemented task is better than multiple incomplete tasks.
* Feel free to make any changes you like to the existing code or project structure, nothing is set in stone.
* Submit your code by sending us a URL to a fork of this repo, or by zipping your local working directory.
* If you have any issues or questions don't hesitate to reach out.

Good luck!