class JiraRoleRepository : BaseSystem
{
    public JiraRoleRepository(string apiUrl, string projectKey, string user, string password)
    {
        this.apiUrl = apiUrl;
        this.user = user;
        this.password = password;
    }

    public List<JiraRole> List()
    {
        var response = HttpGet($"{apiUrl}role");
        var list = JArray.Parse(response).ToList();
        var res = list.Select(i => i.ToObject<JiraRole>()).ToList();
        return res;
    }

    public JiraRole Get(string key)
    {
        var response = HttpGet($"{apiUrl}role/{key}");
        var u = JObject.Parse(response).ToObject<JiraRole>();
        return u;
    }
    public bool Delete(int id)
    {
        return HttpDelete($"{apiUrl}role/{id}");
    }
}