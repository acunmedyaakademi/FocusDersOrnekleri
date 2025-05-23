namespace UserRoles.Models;

public enum Roles
{
    User = 1,
    Editor = 2,
    Admin = 3
    // normal kullanıcı -> kendi ile ilişkili düzenlemeler veya yorum vb.
    // editör -> diğer içeriklere müdahale, onaylama yapabilir
    // admin -> tüm yetkilere sahip. yeni adminler atayabilir. yeni editör rolü verebilir.
}