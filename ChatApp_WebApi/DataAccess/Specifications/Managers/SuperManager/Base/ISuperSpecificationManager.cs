using DataAccess.Specifications.Managers.Entities.Base;

namespace DataAccess.Specifications.Managers.SuperManager.Base;

public interface ISuperSpecificationManager
{
    IChatGroupSpecificationManager ChatGroup { get; }

    IChatGroupMemberSpecificationManager ChatGroupMember { get; }

    IChatMessageSpecificationManager ChatMessage { get; }

    IRefreshTokenSpecificationManager RefreshToken { get; }

    IUserSpecificationManager User { get; }

    IUserRoleSpecificationManager UserRole { get; }
}
