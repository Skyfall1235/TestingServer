public record HTML_Error(int errorCode,string Message);
public static class CommonErrors
{
    // 1xx Informational Responses
    public static readonly HTML_Error Continue = new(100, "The client should continue with its request.");
    public static readonly HTML_Error SwitchingProtocols = new(101, "The server is switching protocols.");

    // 2xx Success
    public static readonly HTML_Error Ok = new(200, "The request was successful.");
    public static readonly HTML_Error Created = new(201, "The request has been fulfilled, and a new resource has been created.");
    public static readonly HTML_Error Accepted = new(202, "The request has been accepted for processing, but the processing is not complete.");
    public static readonly HTML_Error NoContent = new(204, "The server has successfully fulfilled the request and there is no content to send back.");

    // 3xx Redirection
    public static readonly HTML_Error MultipleChoices = new(300, "The requested resource has multiple choices.");
    public static readonly HTML_Error MovedPermanently = new(301, "The requested resource has been assigned a new permanent URI.");
    public static readonly HTML_Error Found = new(302, "The requested resource has been temporarily moved.");
    public static readonly HTML_Error NotModified = new(304, "The requested resource has not been modified since the last request.");

    // 4xx Client Errors
    public static readonly HTML_Error BadRequest = new(400, "The server could not understand the request due to invalid syntax.");
    public static readonly HTML_Error Unauthorized = new(401, "The request requires user authentication.");
    public static readonly HTML_Error Forbidden = new(403, "The server understood the request but refuses to authorize it.");
    public static readonly HTML_Error NotFound = new(404, "The server has not found anything matching the Request-URI.");
    public static readonly HTML_Error MethodNotAllowed = new(405, "The method specified in the Request-Line is not allowed for the resource identified by the Request-URI.");
    public static readonly HTML_Error Conflict = new(409, "The request could not be completed due to a conflict with the current state of the resource.");

    // 5xx Server Errors
    public static readonly HTML_Error InternalServerError = new(500, "The server encountered an unexpected condition which prevented it from fulfilling the request.");
    public static readonly HTML_Error NotImplemented = new(501, "The server does not support the functionality required to fulfill the request.");
    public static readonly HTML_Error ServiceUnavailable = new(503, "The server is currently unable to handle the request due to a temporary overloading or maintenance of the server.");

    // Common HTML markup errors
    public static readonly HTML_Error MissingDoctype = new(0, "Missing or incorrect DOCTYPE declaration.");
    public static readonly HTML_Error UnclosedTags = new(0, "Unclosed or mismatched HTML tags (e.g., a missing </div>).");
    public static readonly HTML_Error MissingAltAttribute = new(0, "Missing or empty 'alt' attribute on <img> tags.");
    public static readonly HTML_Error IncorrectNesting = new(0, "Incorrect nesting of elements (e.g., a <div> inside a <p>).");
    public static readonly HTML_Error InlineStyles = new(0, "Using inline styles or scripts instead of separate CSS and JS files.");
    public static readonly HTML_Error MissingViewport = new(0, "Missing `<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">` for mobile responsiveness.");
    public static readonly HTML_Error NonSemanticElements = new(0, "Using non-semantic elements where a more appropriate tag exists (e.g., using a <div> instead of a <button>).");
    public static readonly HTML_Error InvalidIds = new(0, "Invalid or duplicate IDs used on elements.");
    public static readonly HTML_Error MixedContent = new(0, "External resources (CSS, JS, images) are using an HTTP protocol on an HTTPS page.");
    public static readonly HTML_Error EmptyHeadings = new(0, "Empty heading tags (e.g., `<h1></h1>`) that harm SEO and accessibility.");
}






