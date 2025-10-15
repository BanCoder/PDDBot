using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDDBot
{
	internal class AppSettings
	{
		public required string Token { get; set; }
		public required string warningSignsURL { get; set; }
		public required string prioritySignsURL { get; set; }
		public required string forbiddingSignsURL { get; set; }
		public required string prescriptiveSignsURL { get; set; }
		public required string signsOfSpecialRegulationsURL { get; set; }
		public required string informationSignsURL { get; set; }
		public required string serviceSignsURL { get; set; }
		public required string additionalInformationSignsURL { get; set; }
	}
}
