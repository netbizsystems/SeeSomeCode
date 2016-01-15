- talk is cheap
- this isn't jepordy (or a spelling bee)
- simple.. we use english (c#). what can possibly go wrong there!
- design at the end and call it refactoring
- let the team decide
- vs keyboard shortcuts... ctrl+R+R


    var response = new HttpResponseMessage();
    response.Content = new StringContent("<html><body>Hello World</body></html>");
    response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
    return response;
