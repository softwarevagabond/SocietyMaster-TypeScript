//Create the common module
(function () {
    angular.
        module('common', ['ngRoute', 'ui.bootstrap']);
})();
// non-SPA views will use Angular controllers created on the appMainModule
(function () {
    angular.module('appMain', ['common']);
})();
var SocietyMaster;
(function (SocietyMaster) {
    var ViewModelHelper = (function () {
        function ViewModelHelper($http) {
            this.$http = $http;
            alert("View Model Helper");
        }
        ViewModelHelper.prototype.apiGet = function (uri, data, success, failure, always) {
            var _this = this;
            this.$http.get('/' + uri, data)
                .then(function (result) {
                success(result);
                if (always != null)
                    always();
                _this.isLoading = false;
            }, function (result) {
                if (failure == null) {
                    if (result.status != 400)
                        _this.modelErrors = [result.status + ':' + result.statusText + ' - ' + result.data.Message];
                    else
                        _this.modelErrors = [result.data.Message];
                    _this.modelIsValid = false;
                }
                else
                    failure(result);
                if (always != null)
                    always();
                _this.isLoading = false;
            });
        };
        ViewModelHelper.prototype.apiPost = function (uri, data, success, failure, always) {
            var _this = this;
            alert("Inside API POsst");
            alert(data.Name);
            this.isLoading = true;
            this.modelIsValid = true;
            this.$http.post('/' + uri, data)
                .then(function (result) {
                success(result);
                if (always != null)
                    always();
                _this.isLoading = false;
            }, function (result) {
                if (failure == null) {
                    if (result.status != 400)
                        _this.modelErrors = [result.status + ':' + result.statusText + ' - ' + result.data.Message];
                    else
                        _this.modelErrors = [result.data.Message];
                    _this.modelIsValid = false;
                }
                else
                    failure(result);
                if (always != null)
                    always();
                _this.isLoading = false;
            });
        };
        ViewModelHelper.$inject = ['$http'];
        return ViewModelHelper;
    })();
    SocietyMaster.ViewModelHelper = ViewModelHelper;
    angular.module('common').service('viewModelHelper', ViewModelHelper);
})(SocietyMaster || (SocietyMaster = {}));
var valJs;
(function (valJs) {
    var Validator = (function () {
        function Validator(rules) {
            this.rules = rules;
            this.setupRules();
        }
        Validator.prototype.PropertyRule = function (propertyName, rules) {
            this.PropertyName = propertyName;
            this.Rules = rules;
        };
        Validator.prototype.ValidateModel = function (model, allPropertyRules) {
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
        };
        Validator.prototype.getMessage = function (prop, rule, defaultMessage) {
            var message = '';
            if (rule.hasOwnProperty('message'))
                message = rule.message;
            else
                message = prop + ': ' + defaultMessage;
            return message;
        };
        Validator.prototype.setupRules = function () {
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
        };
        return Validator;
    })();
    valJs.Validator = Validator;
    angular.module('common').service('validator', Validator);
})(valJs || (valJs = {}));
//# sourceMappingURL=App.js.map