using System.Globalization;

namespace WebEcommerce.Models.Helper;

public class CookieHelper
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CookieHelper(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public void setTokenCookie(string token)
    {
        // append cookie with refresh token to the http response
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTime.UtcNow.AddDays(7)
        };
        _httpContextAccessor.HttpContext?.Response.Cookies.Append("refreshToken", token, cookieOptions);
    }

    public string? getTokenCookie()
    {
        string? Token = _httpContextAccessor.HttpContext?.Request?.Cookies["refreshToken"]?.ToString();
        return Token;
    }

    public void LogOutTokenCookie()
    {
        _httpContextAccessor.HttpContext?.Response.Cookies.Delete("refreshToken");
    }

    public void removeTokenCookie(string keyToRemove)
    {
        _httpContextAccessor.HttpContext?.Response.Cookies.Delete(keyToRemove);
    }

    //private string ipAddress()
    //{
    //    // get source ip address for the current request
    //    if (Request.Headers.ContainsKey("X-Forwarded-For"))
    //        return Request.Headers["X-Forwarded-For"];
    //    else
    //        return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
    //}
}

