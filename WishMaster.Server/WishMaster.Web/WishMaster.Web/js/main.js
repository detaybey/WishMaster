'use strict';

/* Controllers */

angular.module('app')
  .controller('AppCtrl', ['$scope', '$window',
    function ($scope, $window) {


        $(document).ready(function () {
            $('.ui.menu .ui.dropdown').dropdown();

            $('.ui.form').form({
                fields: {
                    email: {
                        identifier: 'email',
                        rules: [
                          {
                              type: 'empty',
                              prompt: 'Please enter your e-mail'
                          },
                          {
                              type: 'email',
                              prompt: 'Please enter a valid e-mail'
                          }
                        ]
                    },
                    password: {
                        identifier: 'password',
                        rules: [
                          {
                              type: 'empty',
                              prompt: 'Please enter your password'
                          },
                          {
                              type: 'length[6]',
                              prompt: 'Your password must be at least 6 characters'
                          }
                        ]
                    }
                }
            });
            //$('.ui.menu a.item')
            //  .on('click', function () {
            //      $(this)
            //        .addClass('active').siblings().removeClass('active')
            //      ;
            //  });
        })

    }]);