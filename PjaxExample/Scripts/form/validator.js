// Definition of Validator class - this class used for classical validation operations with jquery
// requires jquery.validate.js

function FormValidator(form) { //e.g: $(.password),'pass field required'

    this.form = form; // form to be validated
    this.form.validate({ // initialize the plugin
        submitHandler: function (form) {
            console.log('valid form submitted');
            return true;//form.submit();
        }
    });
}

FormValidator.prototype.validateFormByClass = function (className, customMessage) {
    if (customMessage == '') {
        customMessage = "Bu alan zorunludur.";    // default error message
    }
    switch (className) {
        case 'validation-required':
            $('.' + className).each(function () {
                $(this).rules('add', {
                    required: true,
                    //number: true,  // add another rule
                    messages: {
                        required: customMessage,
                    }
                });
            });
            break;
        case 'validation-plate':
            $('.' + className).each(function () {
                $(this).rules('add', {
                    required: true,
                    maxlength: 10,
                    //number: true,  // add another rule
                    messages: {
                        required: customMessage,
                        maxlength: "Max 10 karakter giriniz. Örn: 34ABC100"
                    }
                });
            });
            break;
        default:
            break;
    }

}

//End of Validator class