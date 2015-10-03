'use strict';

/* Controllers */

angular.module('app')
  .controller('AppCtrl', ['$scope', '$window',
    function ($scope, $window) {
        $('.ui.dropdown').dropdown();
    }]);