public class CDNUserDTO
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Skill { get; set; }
    public string? Hobby { get; set; }

    public CDNUserDTO() {}
    public CDNUserDTO(CDNUser cdnuser) =>
    (Id, Username, Email, Phone, Skill, Hobby) = 
    (cdnuser.Id, cdnuser.Username, cdnuser.Email, 
    cdnuser.Phone, cdnuser.Skill, cdnuser.Hobby);
}