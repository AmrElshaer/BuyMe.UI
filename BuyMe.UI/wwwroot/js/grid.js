function IsJsonString(str) {
    try {
        JSON.parse(str);
    } catch (e) {
        return false;
    }
    return true;
}
function getBase64(file, elementId) {
    var reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = function () {
        var inputElement = document.getElementById(elementId);
        inputElement.value = reader.result;
    };
}
function displayErrors(err) {
    var grid = document.getElementById("Grid").ej2_instances[0];
    if (err.error[0].error.status === 400 && IsJsonString(err.error[0].error.responseText)) {
        $('.validErrorMess').remove();
        const validationErrorDictionary = JSON.parse(err.error[0].error.responseText);
        for (const fieldName in validationErrorDictionary) {
            if (validationErrorDictionary.hasOwnProperty(fieldName)) {
                var validationEle = $(".e-edit-dialog .form-row div.e-float-input #" + fieldName);
                var spanEle = document.createElement("span");
                spanEle.textContent = '*' + validationErrorDictionary[fieldName];
                spanEle.style.color = "red";
                spanEle.className = "validErrorMess"
                validationEle.parent().remove("span");
                validationEle.parent().append(spanEle)
            }
        }
    }
    else {
        var validationEle = $(".e-edit-dialog");
        var spanEle = document.createElement("span");
        spanEle.textContent = '* Please Check Your Connection';
        spanEle.style.color = "red";
        validationEle.append(spanEle)
    }
}
function appendElement(elementString, form) {
    form.querySelector("#dialogTemp").innerHTML = elementString;
    var script = document.createElement('script');
    script.type = "text/javascript";
    var serverScript = form.querySelector("#dialogTemp").querySelector('script');
    script.textContent = serverScript.innerHTML;
    document.head.appendChild(script);
    serverScript.remove();
}