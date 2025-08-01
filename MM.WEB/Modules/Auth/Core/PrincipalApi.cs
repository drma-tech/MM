﻿using MM.Shared.Models.Auth;

namespace MM.WEB.Modules.Auth.Core;

public class PrincipalApi(IHttpClientFactory factory) : ApiCosmos<ClientePrincipal>(factory, "principal")
{
    public async Task<ClientePrincipal?> Get(bool isUserAuthenticated, bool setNewVersion = false)
    {
        if (isUserAuthenticated) return await GetAsync(Endpoint.Get, null, setNewVersion);

        return null;
    }

    public async Task<string?> GetEmail(string? token)
    {
        return await GetValueAsync($"{Endpoint.GetEmail}?token={token}", null);
    }

    public async Task<ClientePrincipal?> Add(ClientePrincipal? obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        return await PostAsync(Endpoint.Add, null, obj);
    }

    public async Task<ClientePrincipal?> Paddle(ClientePrincipal? obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        return await PutAsync(Endpoint.Paddle, null, obj);
    }

    public async Task Remove()
    {
        await DeleteAsync(Endpoint.Remove, null);
    }

    public async Task<ClientePrincipal?> Public()
    {
        return await PutAsync<ClientePrincipal>(Endpoint.Public, null, null);
    }

    public async Task<ClientePrincipal?> Private()
    {
        return await PutAsync<ClientePrincipal>(Endpoint.Private, null, null);
    }

    private struct Endpoint
    {
        public const string Get = "principal/get";
        public const string GetEmail = "public/principal/get-email";
        public const string Add = "principal/add";
        public const string Paddle = "principal/paddle";
        public const string Remove = "principal/remove";
        public const string Public = "principal/public";
        public const string Private = "principal/private";
    }
}