app.controller('MainController', ['$scope', 'issues', function($scope, issues) {
  issues.success(function(data) {
    $scope.issuesSevenDays = data;
  });
}]);