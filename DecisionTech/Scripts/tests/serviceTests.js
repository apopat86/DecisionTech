///<reference path="jasmine.js"/>
///<reference path="../../Scripts/angular.min.js"/>
///<reference path="../../Scripts/angular-mocks.js"/>
///<reference path="../../Scripts/angular-route.js"/>
///<reference path="../app/home/dealCtrl.js"/>
///<reference path="../app/home/dealService.js"/>



describe('Deal Service', function () {

    var dealService, httpBackend;

    beforeEach(function () {
        module('dealApp');

        inject(function ($httpBackend, _dealService_) {
            dealService = _dealService_;
            httpBackend = $httpBackend;
        });
    });

    afterEach(function () {
        httpBackend.verifyNoOutstandingExpectation();
        httpBackend.verifyNoOutstandingRequest();
    });

    it('should have a getDeal function', function () {
        expect(angular.isFunction(dealService.getDeal)).toBe(true);
    });
    
    it('should receive a bundle object', function () {        
        var returnData = {"bundleType": "BroadbandAndHomephone", "bundleId": 3027};
        
        httpBackend.expectGET('/Home/GetDeal').respond(returnData);
        
        var returnedPromise = dealService.getDeal();
        
        var result;
        returnedPromise.then(function (response) {
            result = response.data;
        });
        
        httpBackend.flush();

        expect(result).toEqual(returnData); 
    });
});

