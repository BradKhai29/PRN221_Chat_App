namespace Helpers;

public static class EmailFormatHelper
{
    // Backing fields.
    private const string AllowedSpecialCharacters = "-_";
    private const int AllowedEmailSectionLength = 2;
    private const string AtSymbol = "@";
    private const string PeriodSymbol = ".";

    /// <summary>
    ///     Verify if the input email address has correct format.
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public static bool IsCorrectFormat(string email)
    {
        var emailSections = email.Trim().Split(AtSymbol);

        bool isValid = VerifyEmailSections(emailSections);

        if (!isValid)
        {
            return false;
        }

        var prefixSection = emailSections[0];
        var domainSection = emailSections[1];

        return VerifyPrefixSection(prefixSection) && VerifyDomainSection(domainSection);
    }

    private static bool VerifyEmailSections(string[] emailSections)
    {
        bool isNotValid = Equals(emailSections, null)
            || emailSections.Length != AllowedEmailSectionLength;

        if (isNotValid)
        {
            return false;
        }

        return true;
    }

    private static bool VerifyPrefixSection(string prefixSection)
    {
        bool hasMultipleParts = prefixSection.Contains(PeriodSymbol);

        // If the prefix section has multiple parts, then verify each part.
        if (hasMultipleParts)
        {
            var multiParts = prefixSection.Split(PeriodSymbol);
            return VerifyPrefixSectionWithMultipleParts(multiParts);
        }

        // Else, verify the format of prefix section with single part.
        return VerifyPrefixPartFormat(prefixSection);
    }

    private static bool VerifyPrefixSectionWithMultipleParts(string[] multipleParts)
    {
        bool isValid = true;

        // For-loop to enhance performance.
        for (int i = 0; i < multipleParts.Length; i++)
        {
            isValid &= VerifyPrefixPartFormat(multipleParts[i]);

            if (!isValid)
            {
                break;
            }
        }

        return isValid;
    }

    /// <summary>
    ///     Verify the format for the prefix-part of email-prefix.
    /// </summary>
    /// <remarks>
    ///     <b>Notice:</b> The prefix of an email may have only one prefix-part
    ///     or multiple prefix parts. This method will verify the prefix-part format. <br/><br/>
    ///     <b>Example 1:</b> abc@gmail.com ;<br/>
    ///     This email prefix is [abc] and this email has only one prefix-part is [abc].<br/><br/>
    ///     <b>Example 2:</b> abc.xyz@gmail.com ;<br/>
    ///     This email prefix is [abc.xyz] and this email has 2 prefix-part is [abc] and [xyz].<br/>
    /// </remarks>
    /// <param name="prefixPart"></param>
    /// <returns>
    ///     The result (bool) of verification process. True mean success.
    /// </returns>
    private static bool VerifyPrefixPartFormat(string prefixPart)
    {
        if (string.IsNullOrEmpty(prefixPart))
        {
            return false;
        }

        int lastIndex = prefixPart.Length - 1;
        for (int index = 0; index < prefixPart.Length; index++)
        {
            char character = prefixPart[index];

            // If first character is not letter, then mail is invalid.
            if (index == 0 && !char.IsLetter(character))
            {
                return false;
            }

            // If last character is not letter or number, then mail is invalid.
            if (index == lastIndex && AllowedSpecialCharacters.Contains(character))
            {
                return false;
            }

            bool isNotValid = !char.IsLetter(character)
                && !char.IsDigit(character)
                && !AllowedSpecialCharacters.Contains(character);

            if (isNotValid)
            {
                return false;
            }
        }

        return true;
    }

    private static bool VerifyDomainSection(string domainSection)
    {
        bool isValid = domainSection.Contains(PeriodSymbol);

        if (!isValid)
        {
            return false;
        }

        isValid = true;
        var domainParts = domainSection.Split(PeriodSymbol);

        // For-loop to enhance performance.
        for (int i = 0; i < domainParts.Length; i++)
        {
            isValid &= VerifyDomainPartFormat(domainParts[i]);

            if (!isValid)
            {
                break;
            }
        }

        return isValid;
    }

    /// <summary>
    ///     Verify the format for the domain-part of email-prefix.
    /// </summary>
    /// <remarks>
    ///     <b>Notice:</b> The domain of an email must have at least 2 domain-part.
    ///     This method will verify the domain-part format. <br/><br/>
    ///     <b>Example 1:</b> abc@gmail.com ;<br/>
    ///     This email domain is [gmail.com]. This email has 2 domain-part 
    ///     is [gmail] and [com].<br/><br/>
    ///     <b>Example 2:</b> abc.xyz@gov.com.vn ;<br/>
    ///     This email domain is [gov.com.vn]. This email has 3 domain-part 
    ///     is [gov], [com] and [vn].<br/>
    /// </remarks>
    /// <param name="domainPart"></param>
    /// <returns>
    ///     The result (bool) of verification process. True mean success.
    /// </returns>
    private static bool VerifyDomainPartFormat(string domainPart)
    {
        const int minLength = 2;
        if (domainPart.Length < minLength)
        {
            return false;
        }

        for (int index = 0; index < domainPart.Length; index++)
        {
            char character = domainPart[index];

            bool isNotValid = !char.IsLetter(character);

            // If the character is not a letter, then mail is invalid.
            if (isNotValid)
            {
                return false;
            }
        }

        return true;
    }
}
