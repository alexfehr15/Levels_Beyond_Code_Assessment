app.factory('issues', ['$http', function($http) { 
  var date = new Date();
  date.setDate(date.getDate() - 7);
	var partialPath = "https:///api.github.com/repos/angular/angular/issues?since=";
  var fullPath = partialPath.concat(date);

	return $http.get(fullPath)
    .success(function(data) { 
      return data; 
    }) 
    .error(function(err) { 
      return err; 
    }); 
}]);