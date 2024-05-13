using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Shared
{
	public class YearLessThanNowAttribute : ValidationAttribute
	{
		public YearLessThanNowAttribute() : base() { }

		public YearLessThanNowAttribute(string errorMessage) : base(errorMessage) { }

		public YearLessThanNowAttribute(Func<string> errorMessageAccessor) : base(errorMessageAccessor) { }

        public override bool IsValid(object value)
		{
			int year = (int)value;
			return year <= DateTime.Now.Year;
		}
	}
}
