using CsvHelper.Configuration;

public class PasswordMap : ClassMap<PasswordManager.PasswordModel>
{
    public PasswordMap()
    {
        Map(m => m.Url).Name("url").Optional();
        Map(m => m.Username).Name("username").Optional();
        Map(m => m.PasswordValue).Name("password").Optional();
        Map(m => m.HttpRealm).Name("httpRealm").Optional();
        Map(m => m.FormActionOrigin).Name("formActionOrigin").Optional();
        Map(m => m.Guid).Name("guid").Optional();
        Map(m => m.TimeCreated).Name("timeCreated").Optional();
        Map(m => m.TimeLastUsed).Name("timeLastUsed").Optional();
        Map(m => m.TimePasswordChanged).Name("timePasswordChanged").Optional();
    }
}