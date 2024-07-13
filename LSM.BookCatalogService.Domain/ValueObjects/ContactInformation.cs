using System.Text.RegularExpressions;
using LSM.BookCatalogService.Domain.Exceptions;

namespace LSM.BookCatalogService.Domain.ValueObjects;

public partial class ContactInformation
{
    private static readonly Regex EmailRegex = GenerateEmailRegex();
    private readonly Dictionary<string, string> _socialNetworks = [];

    public string Email { get; }

    public IReadOnlyDictionary<string, string> SocialNetworks
    {
        get
        {
            var resultDictionary = _socialNetworks.ToDictionary();
            resultDictionary.Add(nameof(Email), Email);
            return resultDictionary.AsReadOnly();
        }
    }

    public ContactInformation(string email)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(email, nameof(email));
        if (EmailRegex.IsMatch(email) is false)
        {
            throw new InvalidEmailException($"Email {email} не валиден");
        }

        Email = email;
    }

    public void AddOrReplaceSocialNetwork(string network, string address)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(network, nameof(network));
        ArgumentException.ThrowIfNullOrWhiteSpace(address, nameof(address));

        if (_socialNetworks.TryAdd(network, address) is false)
        {
            _socialNetworks[network] = address;
        }
    }

    [GeneratedRegex("([a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+\\.[a-zA-Z]+)")]
    private static partial Regex GenerateEmailRegex();
}