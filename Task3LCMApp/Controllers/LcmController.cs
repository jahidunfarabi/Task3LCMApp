using Microsoft.AspNetCore.Mvc;

namespace Task3LCMApp.Controllers
{
    [ApiController]
    [Route("jahidunmuntaka25_gmail_com")] //my email
    public class LcmController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetLcm([FromQuery] string? x, [FromQuery] string? y)
        {
            if (!long.TryParse(x, out long numberX) || !long.TryParse(y, out long numberY))
            {
                return Content("NaN", "text/plain");
            }

            if (numberX <= 0 || numberY <= 0)
            {
                return Content("NaN", "text/plain");
            }

            try
            {
                long lcm = CalculateLCM(numberX, numberY);
                return Content(lcm.ToString(), "text/plain");
            }
            catch
            {
                return Content("NaN", "text/plain");
            }
        }

        private long CalculateGCD(long first, long second)
        {
            while (second != 0)
            {
                long remainder = first % second;
                first = second;
                second = remainder;
            }
            return first;
        }

        private long CalculateLCM(long numberX, long numberY)
        {
            long gcd = CalculateGCD(numberX, numberY);
            return (numberX / gcd) * numberY;
        }
    }
}