const request = require('request');
const ids = [744410,
    744411,
    744413,
    744414,
    744415,
    743175,
    891123,
    744303,
    745063,
    745064,
    745070,
    745074,
    745080,
    745084,
    745085,
    745086,
    745089,
    745091,
    745095,
    745098,
    745105,
    745106,
    745108,
    745109,
    745110,
    745111,
    745116,
    745115,
    745101,
    745114];
username = "asuwalka",
    password = "devf@ctory@2",
    auth = "Basic " + new Buffer(username + ":" + password).toString("base64");

for (const x of ids) {

    request(
        {
            url: `https://testrail.devfactory.com/index.php?/api/v2/get_case/${x}`,
            headers: {
                "Authorization": auth,
                'Content-Type': 'application/json'
            }
        },

        function (error, response, body) {
            body = JSON.parse(body);
            console.log(body.id + '|' + body.suite_id);
            // Do more stuff wi/th 'body' here
        }
    );
}