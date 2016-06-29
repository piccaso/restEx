using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace restEx.Controllers
{

    public class CounterController : ApiController
    {
        private static long _counterValue = 0;


        /// <summary>
        /// Get the counter value
        /// </summary>
        /// <returns>64bit number</returns>
        [HttpGet]
        public long Get()
        {
            return Interlocked.Read(ref _counterValue);
        }
        /// <summary>
        /// Increment the counter by 1
        /// </summary>
        /// <returns>64bit number</returns>
        [HttpPost]
        public long Increment()
        {
            Interlocked.Increment(ref _counterValue);
            return Get();
        }
        /// <summary>
        /// Set counter value
        /// </summary>
        /// <param name="value">64bit number</param>
        /// <returns>64bit number</returns>
        [HttpPost]
        public long Set(long value)
        {
            Interlocked.Exchange(ref _counterValue, value);
            return Get();
        }

    }
}
