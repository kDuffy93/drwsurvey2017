
    var pictureSource; // picture source
    var destinationType; // sets the format of returned value 

    // Wait for Cordova to connect with the device
    document.addEventListener("deviceready", onDeviceReady, false);

    // Cordova is ready to be used!
    function onDeviceReady() {
        pictureSource = navigator.camera.PictureSourceType;
        destinationType = navigator.camera.DestinationType;
    }

    // Take picture using device camera and retrieve image as base64-encoded string
    function capturePhoto() {
        navigator.camera.getPicture(onPhotoDataSuccess, onFail, {
            quality: 50, allowEdit: true,
            destinationType: destinationType.DATA_URL
        });
    }

    // Called if something bad happens. 
    function onFail(message) {
        alert('Failed because: ' + message);
    }

    function onPhotoDataSuccess(imageData) {
        // Uncomment to view the base64 encoded image data
        // console.log(imageData);

    }
