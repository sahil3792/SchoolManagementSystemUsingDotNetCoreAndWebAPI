namespace SchoolManagementWebApp.Models
{
	public class Assignment
	{

		public int Id { get; set; }
		public string AssignmentName	{ get; set; }
		public DateOnly StartDate	{ get; set; }
		public DateOnly EndDate { get; set; }
		public string File {  get; set; }
		public string ClassId { get; set; }
	}
}
