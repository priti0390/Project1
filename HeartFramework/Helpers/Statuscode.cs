using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeartFramework.Helpers
{
    public static class Statuscode
    {
        /// <summary>
        ///All possible status codes for API
        /// </summary>
        public static int OK = 200;
        public static int CREATED = 201;
        public static int ACCEPTED = 202;
        public static int NON_AUTHORITATIVE_INFORMATION = 203;
        public static int NO_CONTENT = 204;
        public static int RESET_CONTENT = 205;
        public static int PARTIAL_CONTENT = 206;
        public static int MULTI_STATUS = 207;
        public static int ALREADY_REPORTED = 208;
        public static int IM_USED = 226;
        public static int MULTIPLE_CHOICES = 300;
        public static int MOVED_PERMANENTLY = 301;
        public static int FOUND = 302;
        public static int SEE_OTHER = 303;
        public static int NOT_MODIFIED = 304;
        public static int USE_PROXY = 305;
        public static int TEMPORARY_REDIRECT = 307;
        public static int PERMANENT_REDIRECT = 308;
        public static int BAD_REQUEST = 400;
        public static int UNAUTHORIZED = 401;
        public static int PAYMENT_REQUIRED = 402;
        public static int FORBIDDEN = 403;
        public static int NOT_FOUND = 404;
        public static int METHOD_NOT_ALLOWED = 405;
        public static int NOT_ACCEPTABLE = 406;
        public static int PRXY_AUTHENTICATION_REQUIRED = 407;
        public static int REQUEST_TIMEOUT = 408;
        public static int CONFLICT = 409;
        public static int GONE = 410;
        public static int LENGTH_REQUIRED = 411
   ; public static int PRECONDITION_FAILED = 412
   ; public static int PAYLOAD_TOO_LARGE = 413
   ; public static int REQUEST_URI_TOO_LONG = 414
   ; public static int UNSUPPORTED_MEDIA_TYPE = 415
   ; public static int REQUESTED_RANGE_NOT_SATISFIABLE = 416
   ; public static int EXPECTATION_FAILED = 417
   ; public static int IM_A_TEAPOT = 418
   ; public static int MISDIRECTED_REQUEST = 421
   ; public static int UNPROCESSABLE_ENTITY = 422
   ; public static int LOCKED = 423
   ; public static int FAILED_DEPENDENCY = 424
   ; public static int UPGRADE_REQUIRED = 426
   ; public static int PRECONDITION_REQUIRED = 428
   ; public static int TOO_MANY_REQUESTS = 429
   ; public static int REQUEST_HEADER_FIELDS_TOO_LARGE = 431
   ; public static int CONNECTION_CLOSED_WITHOUT_RESPONSE = 444
   ; public static int UNAVAILABLE_FOR_LEGAL_REASONS = 451
   ; public static int CLIENT_CLOSED_REQUEST = 499
   ; public static int INTERNAL_SERVER_ERROR = 500
   ; public static int NOT_IMPLEMENTED = 501
   ; public static int BAD_GATEWAY = 502
   ; public static int SERVICE_UNAVAILABLE = 503
   ; public static int GATEWAY_TIMEOUT = 504
   ; public static int HTTP_VERSION_NOT_SUPPORTED = 505
   ; public static int VARIANT_ALSO_NEGOTIATES = 506
   ; public static int INSUFFICIENT_STORAGE = 507
   ; public static int LOOP_DETECTED = 508
   ; public static int NOT_EXTENDED = 510
   ; public static int NETWORK_AUTHENTICATION_REQUIRED = 511
   ; public static int NETWORK_CONNECT_TIMEOUT_ERROR = 599;
    }
}
