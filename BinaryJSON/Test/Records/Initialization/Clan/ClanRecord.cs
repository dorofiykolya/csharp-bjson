using System;


namespace Records.Initialization
{

	[Serializable]
	public class ClanRecord
	{
		public int id;
		public string name;
		public string description;
		public int type;
		public string icon;
		public int rating;
		public int requiredRating;
		public int position;
		public ClanMemberRecord[] members;
		public string extendedInfo;

	    public ClanRecord()
	    {
            name = String.Empty;
            description = String.Empty;
	        icon = String.Empty;
	    }
	}

}
