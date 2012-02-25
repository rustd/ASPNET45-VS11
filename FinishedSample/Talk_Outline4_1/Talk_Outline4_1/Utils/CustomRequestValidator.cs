using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Util;
/// <summary>
/// Summary description for CustomRequestValidation
/// </summary>
/// 
namespace Talk_Outline4_1 {
    public class CustomRequestValidation : RequestValidator {
        public CustomRequestValidation() {
            //
            // TODO: Add constructor logic here
            //
        }

        protected override bool IsValidRequestString(
           HttpContext context, string value,
           RequestValidationSource requestValidationSource, string collectionKey,
           out int validationFailureIndex) {
            validationFailureIndex = -1;  //Set a default value for the out parameter.
            //Allow the query-string key data to have a value that is formatted like XML.
            if ((requestValidationSource == RequestValidationSource.Form)) {
                //The querystring value "<example>1234</example>" is allowed.
                if (value.ToString().StartsWith("<")) {
                    validationFailureIndex = -1;
                    return true;
                }
                else
                    //Leave any further checks to ASP.NET.
                    return base.IsValidRequestString(context, value,
                    requestValidationSource,
                    collectionKey, out validationFailureIndex);
            }
            //All other HTTP input checks are left to the base ASP.NET implementation.
            else {
                return base.IsValidRequestString(context, value, requestValidationSource,
                                                 collectionKey, out validationFailureIndex);
            }
        }
    }
}