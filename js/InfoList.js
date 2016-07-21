var RequisitionModule = angular.module( 'RequisitionApp', []);
var identifier = 0;


RequisitionModule.controller('RequisitionController', function($scope,$filter,RequisitionService){
$scope.pageIndex = 1;
$scope.pageSize = 5;
$scope.pageContent = [];
$scope.currentPage = 1;
$scope.pageUnderIndex = [1,2,3,4,5];
$scope.editModel = {};
$scope.SRNo = "";

//start function here
$scope.bindDataEdit = function (html) {
  // body...
var item = $scope.pageContent[html.$index];
$scope.editModel = item;
};
//FUnction to reach Service and fetch data by page Index
$scope.GetListService = function(argument) {
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



$scope.CreateNewRequisition = function () {
    RequisitionService.CreateNewRequisition().then(function(argument) {
    console.log(argument);
  });
};


$scope.EditRecord = function () {
  $scope.status = "updating...";
  RequisitionService.UpdateItem($scope.editModel).then(function(response){
  if(response.data){
  $scope.status = "successfully update";
  }
  });
};

$scope.close = function (argument) {
  // body...
  $scope.SRNo = "";
  $scope.matchStatus = "";
  $scope.status = "";
};

$scope.SRNoValidator = function (argument) {
  // body...
  console.log(argument.SRNo);
  var regex = /^\d{6}-\d{6}$/;
  if(!regex.test(argument.SRNo) || argument.SRNo =="" ){
    $scope.matchStatus = "Please type in a right SRNo.";
  }
  else{
    $scope.matchStatus = "Checking";
    RequisitionService.GetSRbyId($scope.SRNo).then(function(response){
      console.log(response);
      if(response.data){
      $scope.matchStatus = "Verified";
      }
      else{
      $scope.matchStatus = "No Record found";
      }
    });
  }
};

$scope.DeleteRecord = function (argument) {
  // body...

RequisitionService.DeleteRecord(argument.SRNo).then(function(response){
if(response.data){
$scope.matchStatus = "Successfully Deleted.";
$scope.GetListService();
}
});

};
// function ended
});


RequisitionModule.service("RequisitionService",function($http){
// start function here
this.DeleteRecord = function (serviceNo) {
  // body...
    var data = JSON.stringify(serviceNo);
    var addr ="http://192.168.0.12/WestCoastStreetService.svc/DeleteRecord" ;
    var request = $http.post(addr,data);
    return request;
};

this.GetSRbyId = function (SRNo) {
  // body...
    var data = JSON.stringify(SRNo);
    var addr = "http://192.168.0.12/WestCoastStreetService.svc/ValidateServiceRequestID";
    var request = $http.post(addr,data);
    return request;
};

this.GetRequisitionByIndex = function(pageIndex, pageSize){
  var address = "http://192.168.0.12/WestCoastStreetService.svc/GetRequistion?pageIndex="+pageIndex+"&?pageSize="+pageSize+"";
  var request = $http.get(address);
   return request;
};

this.CreateNewRequisition = function () {
  // body...
  var value = {
   RequestedBy : "lujeng",
   SRNo : "SRNo---000010",
   SRType : 123,
   SRStatusID : 4,
   Feedback:"good",
   RequestDate : "20160501",
   ShopName : "se.ShopName",
   Remark : "se.Remark",
   Email : "se.Email",
   ContactNumber : "123456"
   };
  var data = JSON.stringify(value);
  var address = "http://192.168.0.12/WestCoastStreetService.svc/CreateNewRequisition";
  var request = $http.post(address,data);
        return request;
};
this.UpdateItem = function (argument) {
  // body...
    var data = JSON.stringify(argument);
  var address = "http://192.168.0.12/WestCoastStreetService.svc/UpdateRequisition";
  var request = $http.post(address,data);
        return request;
};


// function ended
});
