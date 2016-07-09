var RequisitionModule = angular.module( 'RequisitionApp', []);
var identifier = 0;


RequisitionModule.controller('RequisitionController', function($scope,$filter,RequisitionService){
$scope.pageIndex = 1;
$scope.pageSize = 5;
$scope.pageContent = [];
$scope.currentPage = 1;
$scope.pageUnderIndex = [1,2,3,4,5];


//start function here

//FUnction to reach Service and fetch data by page Index
$scope.GetListService = function(argument) {
  console.log("1");
  RequisitionService.GetRequisitionByIndex($scope.pageIndex, $scope.pageSize).then(function(response){
  $scope.pageContent = response.data;
  });
};

$scope.GetRequisitionByIndex = function(html){
  //to secure when first time came, we pass the default values
if(identifier != 0){
$scope.pageIndex = html.index;
$scope.currentPage = html.index;
}
$scope.GetListService();
identifier++;
};
$scope.GetRequisitionByIndex();

$scope.PrePage = function (argument) {
// To update the index sequence with we are clicking pre page. $scope.currentPage - 1 != 0 is to prevent from go to -1 page
  if($scope.currentPage == $scope.pageUnderIndex[0] && $scope.currentPage - 1 != 0){
    for(x in $scope.pageUnderIndex){
      $scope.pageUnderIndex[x] = $scope.pageUnderIndex[x]-1;
    }
  }

//To secure when we at the frist page, we won't go to -1 page
if($scope.currentPage - 1 != 0){
$scope.currentPage = $scope.currentPage - 1;
$scope.pageIndex = $scope.pageIndex - 1;
$scope.GetListService();
}

};

$scope.NextPage = function (argument) {
  //When we access the page 6, we will add up the index and show the correct data. $scope.pageContent.length == $scope.pageSize mean only the data size equal to the pagesize,
  //we can see that we have next page, otherwise, this is the final page, we do not allow adding index.
  if($scope.currentPage == $scope.pageUnderIndex[4] && $scope.pageContent.length == $scope.pageSize){
    for(x in $scope.pageUnderIndex){
      $scope.pageUnderIndex[x] = $scope.pageUnderIndex[x]+1;
    }
  }
  //To secure the current page is not the final page.
  if($scope.pageContent.length == $scope.pageSize){
  $scope.currentPage = $scope.currentPage + 1;
  $scope.pageIndex = $scope.pageIndex + 1;
  $scope.GetListService();
  }

};

// function ended
});


RequisitionModule.service("RequisitionService",function($http){
// start function here
this.GetRequisitionByIndex = function(pageIndex, pageSize){
  var address = "http://192.168.0.11/WestCoastStreetService.svc/GetRequistion?pageIndex="+pageIndex+"&?pageSize="+pageSize+"";
  var request = $http.get(address);
   return request;
};

// function ended
});
