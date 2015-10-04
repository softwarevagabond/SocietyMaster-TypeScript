//Create the common module
((): void => {
    angular.
        module('common', ['ngRoute', 'ui.bootstrap']);
})(); 

// non-SPA views will use Angular controllers created on the appMainModule

((): void=> {
    angular.module('appMain', ['common']);
})();

module SocietyMaster {

    //Services are used in many places so added export 
   export interface IViewModelHelper {
        modelIsValid: boolean;
        modelErrors: any[];
        isLoading: boolean;

        apiGet(uri: string, data: any, success: any, failure: any, always: any): void;
        apiPost(uri: string, data: any, success: any, failure: any, always: any): void;
    }

  export  class ViewModelHelper implements IViewModelHelper {

        static $inject = ['$http'];
        constructor(private $http: ng.IHttpService) {
            alert("View Model Helper");
        }
        modelIsValid: boolean;
        modelErrors: any[];
        isLoading: boolean;

        apiGet(uri: string, data: any, success: any, failure: any, always: any): void {
            this.$http.get('/' + uri, data)
                .then((result) => {
                    success(result);
                    if (always != null)
                        always();
                    this.isLoading = false;
                },
                    (result) => {
                        if (failure == null) {
                            if (result.status != 400)
                                this.modelErrors = [result.status + ':' + result.statusText + ' - ' + result.data.Message];
                            else
                                this.modelErrors = [result.data.Message];
                            this.modelIsValid = false;
                        }
                        else
                            failure(result);
                        if (always != null)
                            always();
                        this.isLoading = false;
                    });
        }
        apiPost(uri: string, data: any, success: any, failure: any, always: any): void {
            alert("Inside API POsst");
            alert(data.Name);
            this.isLoading = true;
            this.modelIsValid = true;
            this.$http.post('/' + uri, data)
                .then((result) => {
                    success(result);
                    if (always != null)
                        always();
                    this.isLoading = false;
                }, (result) => {
                    if (failure == null) {
                        if (result.status != 400)
                            this.modelErrors = [result.status + ':' + result.statusText + ' - ' + result.data.Message];
                        else
                            this.modelErrors = [result.data.Message];
                        this.modelIsValid = false;
                    }
                    else
                        failure(result);
                    if (always != null)
                        always();
                    this.isLoading = false;
                });
        }
   }
    angular.module('common').service('viewModelHelper', ViewModelHelper);
}

module valJs {

    export interface IValidator {

        PropertyName: string;
        Rules: any[];

        PropertyRule(propertyName: string, rules: any[]): void;
        ValidateModel(model: any, allPropertyRules: any[]): void;
        getMessage(prop: string, rule: any, defaultMessage: string): string;
        setupRules(): void;
    }

   export class Validator implements IValidator {
        PropertyName: string;
        Rules: any[];

        constructor(private rules: any[]) {
           this.setupRules();
        }
        PropertyRule(propertyName: string, rules: any[]): void {
            this.PropertyName = propertyName;
            this.Rules = rules;
        }

        ValidateModel(model: any, allPropertyRules: any[]): void {
            var errors = [];
            var props = Object.keys(model);
            for (var i = 0; i < props.length; i++) {
                var prop = props[i];
                for (var j = 0; j < allPropertyRules.length; j++) {
                    var propertyRule = allPropertyRules[j];
                    if (prop == propertyRule.PropertyName) {
                        var propertyRules = propertyRule.Rules;

                        var propertyRuleProps = Object.keys(propertyRules);
                        for (var k = 0; k < propertyRuleProps.length; k++) {
                            var propertyRuleProp = propertyRuleProps[k];
                            if (propertyRuleProp != 'custom') {
                                var rule = this.rules[propertyRuleProp];
                                var params = null;
                                if (propertyRules[propertyRuleProp].hasOwnProperty('params'))
                                    params = propertyRules[propertyRuleProp].params;
                                var validationResult = rule.validator(model[prop], params);
                                if (!validationResult) {
                                    errors.push(this.getMessage(prop, propertyRuleProp, rule.message));
                                }
                            }
                            else {
                                var validator = propertyRules.custom.validator;
                                var value = null;
                                if (propertyRules.custom.hasOwnProperty('params')) {
                                    value = propertyRules.custom.params;
                                }
                                var result = validator(model[prop], value());
                                if (result != true) {
                                    errors.push(this.getMessage(prop, propertyRules.custom, 'Invalid value.'));
                                }
                            }
                        }
                    }
                }
            }

            model['errors'] = errors;
            model['isValid'] = (errors.length == 0);
        }

        getMessage(prop: string, rule: any, defaultMessage: string): string {
            var message = '';
            if (rule.hasOwnProperty('message'))
                message = rule.message;
            else
                message = prop + ': ' + defaultMessage;
            return message;
        }

        setupRules(): void {
            this.rules['required'] = {
                validator: function (value, params) {
                    return !(value.trim() == '');
                },
                message: 'Value is required.'
            };
            this.rules['minLength'] = {
                validator: function (value, params) {
                    return !(value.trim().length < params);
                },
                message: 'Value does not meet minimum length.'
            };
            this.rules['pattern'] = {
                validator: function (value, params) {
                    var regExp = new RegExp(params);
                    return !(regExp.exec(value.trim()) == null);
                },
                message: 'Value must match regular expression.'
            };
        }  
    }

    angular.module('common').service('validator', Validator);
}