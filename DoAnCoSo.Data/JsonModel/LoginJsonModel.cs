using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCoSo.Data.JsonModel
{
	public class LoginJsonModel
	{
		public bool isSuccessfully { get; set; }
		public bool? isRoot { get; set; }
		public LoginJsonModel()
		{
			this.isSuccessfully = false;
			this.isRoot = false;
		}
		public LoginJsonModel(bool isSuccessfully, bool? isRoot)
		{
			this.isSuccessfully = isSuccessfully;
			this.isRoot = isRoot;
		}
	}
}
