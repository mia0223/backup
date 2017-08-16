var requestify = require('requestify');

requestify.get('http://sample-env-1.rfwpmfcpds.us-west-2.elasticbeanstalk.com/webapi/profiles').then(function (response) {
    // Get the response body
    console.log(response.getBody());
});
