///<reference path="jasmine.js"/>
///<reference path="../../Scripts/angular.min.js"/>
///<reference path="../../Scripts/angular-mocks.js"/>
///<reference path="../../Scripts/angular-route.js"/>
///<reference path="../app/home/dealCtrl.js"/>
///<reference path="../app/home/dealService.js"/>

describe('Deal Controller', function () {

    var $scope, $controller;
    var dealCtrl;
    var dealService, httpBackend;
    var expectedResponse = { "bundleType": "BroadbandAndHomephone", "bundleId": 3027 };

    beforeEach(function () {
        
        module('dealApp');

        inject(function (_$httpBackend_, _dealService_, $rootScope, _$controller_) {
            dealService = _dealService_;
            httpBackend = _$httpBackend_;
            $scope = $rootScope.$new();
            $controller = _$controller_;
        });   
       
    });

    afterEach(function () {
        httpBackend.verifyNoOutstandingExpectation();
        httpBackend.verifyNoOutstandingRequest();
    });

    describe('should load data successfully', function () {
        beforeEach(function () {
            httpBackend.expectGET('/Home/GetDeal').respond(expectedResponse);
            dealCtrl= $controller('dealCtrl', {
                $scope: $scope,
                dealService: dealService
            });
            httpBackend.flush();
        });


        it('should start with isLoading and hasError populated', function () {
            expect($scope.isLoading).toEqual(false);
            expect($scope.hasError).toEqual(false);
        });

        it('should set the deal record', function () {
            expect(dealCtrl.deal).toEqual(expectedResponse);
        });

        it('should strip brackets and colons correctly', function () {
            expect($scope.stripCharacters('(test)')).toEqual('test');
            expect($scope.stripCharacters('test:')).toEqual('test');
        });

        it('should strip brackets and colons and capitalise correctly', function () {
            expect($scope.capitalizeAndStripCharacters('(test)')).toEqual('Test');
            expect($scope.capitalizeAndStripCharacters('test:')).toEqual('Test');
        });
    });
    
    
  
});