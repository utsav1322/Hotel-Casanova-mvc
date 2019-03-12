var User = new Object();
var Login = new Object();
var data = new FormData;

function UNameValidation() {
    var UserName = document.getElementById('username').value;

    var val = /^[a-zA-Z-0-9_]+$/;
    //  alert("function");
    if (UserName == "") {
        document.getElementById('usernameerror').textContent = 'Please Enter User-Name';
        document.getElementById("usernameerror").style.visibility = "visible";
        document.getElementById("usernameerror").style.color = "red";
        document.getElementById('usernameerror').focus();

        //UserName.focus();
        return false;
    }
    else if (val.test(UserName)) {
        document.getElementById("usernameerror").style.visibility = "hidden";
        return true;
    }
    else {
        document.getElementById("usernameerror").textContent = "User-Name accepts Only letters, numbers and underscore";
        document.getElementById("usernameerror").style.visibility = "visible";
        document.getElementById("usernameerror").style.color = "red";

        // UserName.focus();
        return false;
    }
}
function FirstNameValidation() {
    FirstName = document.getElementById("firstname").value;

    var val = /^[a-zA-Z ]+$/;
    if (FirstName == "") {
        document.getElementById('firstnameerror').textContent = 'Please Enter First Name';
        document.getElementById("firstnameerror").style.visibility = "visible";
        document.getElementById("firstnameerror").style.color = "red";
        document.getElementById('firstnameerror').focus();

        // FirstName.focus();
        return false;
    }
    else if (val.test(FirstName)) {
        document.getElementById("firstnameerror").style.visibility = "hidden";
        return true;
    }
    else {
        document.getElementById("firstnameerror").textContent = "First Name accepts Only letters";
        document.getElementById("firstnameerror").style.visibility = "visible";
        document.getElementById("firstnameerror").style.color = "red";

        //FirstName.focus();
        return false;
    }
}
function LastNameValidation() {
    LastName = document.getElementById("lastname").value;

    var val = /^[a-zA-Z ]+$/;
    if (LastName == "") {
        document.getElementById('lastnameerror').textContent = 'Please Enter Last Name';
        document.getElementById("lastnameerror").style.visibility = "visible";
        document.getElementById("lastnameerror").style.color = "red";
        document.getElementById('lastnameerror').focus();

        //LastName.focus();
        return false;
    }
    else if (val.test(LastName)) {
        document.getElementById("lastnameerror").style.visibility = "hidden";
        return true;
    }
    else {
        document.getElementById("lastnameerror").textContent = "Last Name accepts Only letters";
        document.getElementById("lastnameerror").style.visibility = "visible";
        document.getElementById("lastnameerror").style.color = "red";

        // LastName.focus();
        return false;
    }
}

function EmailValidation() {
    Email = document.getElementById("email").value;

    var val = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    if (Email == "") {
        document.getElementById('emailerror').textContent = 'Please Enter Email';
        document.getElementById("emailerror").style.visibility = "visible";
        document.getElementById("emailerror").style.color = "red";
        document.getElementById('emailerror').focus();

        //Email.focus();
        return false;
    }
    else if (val.test(Email)) {
        document.getElementById("emailerror").style.visibility = "hidden";
        return true;
    }
    else {
        document.getElementById("emailerror").textContent = "Email address in not in Validae formate";
        document.getElementById("emailerror").style.visibility = "visible";
        document.getElementById("emailerror").style.color = "red";

        // Email.focus();
        return false;
    }
}

function PhonenoValidation() {
    Mobile = document.getElementById("mobile").value;

    // val = /^[0-9]+$/;
    val = /^\d{10}$/;

    if (Mobile == "") {
        document.getElementById('mobileerror').textContent = 'Please Enter Phone no';
        document.getElementById("mobileerror").style.visibility = "visible";
        document.getElementById("mobileerror").style.color = "red";
        document.getElementById('mobileerror').focus();

        // Mobile.focus();
        return false;
    }
    else if (val.test(Mobile)) {
        document.getElementById("mobileerror").style.visibility = "hidden";
        return true;
    }
    else {
        document.getElementById("mobileerror").textContent = "Phone Number Only contain numbers";
        document.getElementById("mobileerror").style.visibility = "visible";
        document.getElementById("mobileerror").style.color = "red";

        // Mobile.focus();
        return false;
    }
}

function PasswordValidation() {
    Password = document.getElementById("password").value;

    var minNumberofChars = 6;
    var maxNumberofChars = 16;
    var val = /^[a-zA-Z0-9!@#$%^&*]{6,20}$/;

    if (Password == "") {
        document.getElementById('passworderror').textContent = 'Please Enter Password';
        document.getElementById("passworderror").style.visibility = "visible";
        document.getElementById("passworderror").style.color = "red";
        document.getElementById('passworderror').focus();

        //   Password.focus();
        return false;
    }
    else if (val.test(Password) && (Password.length >= minNumberofChars || Password.length <= maxNumberofChars)) {
        document.getElementById("passworderror").style.visibility = "hidden";
        return true;
    }
    else {
        document.getElementById("passworderror").textContent = "Password Should be between 6 - 20 ";
        document.getElementById("passworderror").style.visibility = "visible";
        document.getElementById("passworderror").style.color = "red";

        //  Password.focus();
        return false;
    }
}

function ConformPasswordValidation() {
    ConfirmPassword = document.getElementById("confirmpassword").value;

    var minNumberofChars = 6;
    var maxNumberofChars = 16;
    var val = /^[a-zA-Z0-9!@#$%^&*]{6,16}$/;

    if (ConfirmPassword == "") {
        document.getElementById('confirmpassworderror').textContent = 'Please Enter ConformPassword';
        document.getElementById("confirmpassworderror").style.visibility = "visible";
        document.getElementById("confirmpassworderror").style.color = "red";
        document.getElementById('confirmpassworderror').focus();

        //  ConfirmPassword.focus();
        return false;
    }
    else if (Password == ConfirmPassword) {
        document.getElementById("confirmpassworderror").style.visibility = "hidden";
        return true;
    }
    else {
        document.getElementById("confirmpassworderror").textContent = "ConformPassword must be match with Password";
        document.getElementById("confirmpassworderror").style.visibility = "visible";
        document.getElementById("confirmpassworderror").style.color = "red";

        //   ConfirmPassword.focus();
        return false;
    }
}
/*

 var UploadImage = function () {
    var file = $("#SelectImage").get(0).files;
    data.append("postedFile", file[0]);
};

*/

/*

//img byte array
var p;
var canvas = document.createElement("canvas");
var img1 = document.createElement("img");

function getBase64Image() {
    p = document.getElementById("fileUpload").value;
    img1.setAttribute('src', p);
    canvas.width = img1.width;
    canvas.height = img1.height;
    var ctx = canvas.getContext("2d");
    ctx.drawImage(img1, 0, 0);
    var dataURL = canvas.toDataURL("image/png");
    //alert("from getbase64 function" + dataURL);
    return dataURL;
}

    //img byte array end here
*/
function Register() {
    var test1 = UNameValidation();
    var test2 = FirstNameValidation();
    var test3 = LastNameValidation();
    var test4 = EmailValidation();
    var test5 = PhonenoValidation();
    var test6 = PasswordValidation();
    var test7 = ConformPasswordValidation();
    // var test8 = getBase64Image();

    if (test1 && test2 && test3 && test4 && test5 && test6 && test7) {
        data.append("UserName", $("#username").val());
        data.append("FirstName", $("#firstname").val());
        data.append("LastName", $("#lastname").val());
        data.append("Email", $("#email").val());
        data.append("Mobile", $("#mobile").val());
        data.append("Password", $("#password").val());
        var file = $("#SelectImage").get(0).files;
        data.append("postedFile", file[0]);
        /*
                User.UserName = $("#username").val();
                User.FirstName = $("#firstname").val();
                User.LastName = $("#lastname").val();
                User.Email = $("#email").val();
                User.Mobile = $("#mobile").val();
                User.Password = $("#password").val();
               // User.Avatar = getBase64Image();
        */
        RegistrationDataPassing();
    }
    else {
        alert("Put data According to given detail");
    }
}

var RegistrationDataPassing = function () {
    //var data = User;
    //var data = $("#Registration").serialize();
    $.ajax({
        type: "post",
        url: "/Registration/AddUser",
        data: data,
        contentType: false,
        processData: false,
        success: function (response) {
            //alert("Hello: " + response.UserName + ".\nCurrent Phone Number is: " + response.Mobile);
            if (response == "User Details Inserted Successfully") {
                $("#message1").show();
                $("#message2").hide();
                window.location.href = "/Login/Index";
            }
            else {
                $("#message1").hide();
                $("#message2").show();
                alert("It is a failure message");
            }
        },
        error: function (response) {
            //alert("It is a  error message" + response.responseText);
            alert("It is a  error message");
        }
    });
};

function login() {
    var test1 = UNameValidation();
    var test2 = PasswordValidation();

    if (test1 && test2) {
        Login.UserName = $("#username").val();
        Login.Password = $("#password").val();

        LoginDataPassing();
    }
    else {
        alert("Put data According to given detail");
    }
}
var LoginDataPassing = function () {
    var data = Login;
    //var data = $("#Registration").serialize();
    $.ajax({
        type: "post",
        url: "/Login/CheckValidUser",
        data: data,
        success: function (response) {
            //alert("Hello: " + response.UserName + ".\nCurrent Phone Number is: " + response.Mobile);
            if (response == "Admin_Login_Successful") {
                $("#message1").hide();
                $("#message2").show();
                window.location.href = "/Login/AdminWelcome";
            }
            else if (response == "User_Login_Successful") {
                $("#message1").hide();
                $("#message2").show();
                window.location.href = "/Login/Welcome";
            }
            else {
                $("#message1").hide();
                $("#message2").show();
                alert("It is a login failure message");
            }
        },
        error: function (response) {
            //alert("It is a  error message" + response.responseText);
            alert("It is a  error message");
        }
    });
};