namespace SoftwareVersion.Extensions
{
    public static class SoftwareVersionExtensions
    {
        public static bool IsValidVersion(this string version){
            if (string.IsNullOrWhiteSpace(version))
                return false;

            var versionParts = version.Split(Constants.VersionPartsDelimeter);

            foreach (var part in versionParts)
            {
                if (!int.TryParse(part, out int i))
                    return false;
            }
            
            return true;
        }

        public static bool IsGreaterThan(this string version, string otherVersion){
            if (!version.IsValidVersion()
                || !otherVersion.IsValidVersion())
                return false;

            var versionParts = version.Split(Constants.VersionPartsDelimeter);
            var otherVersionParts = otherVersion.Split(Constants.VersionPartsDelimeter);

            var majorVersion = int.Parse(versionParts[0]);
            var otherMajorVersion = int.Parse(otherVersionParts[0]);
            if (majorVersion > otherMajorVersion)
                return true;
            if (majorVersion < otherMajorVersion)
                return false;

            var minorVersion = versionParts.Length > 1
                ? int.Parse(versionParts[1])
                : 0;
            var otherMinorVersion = otherVersionParts.Length > 1
                ? int.Parse(otherVersionParts[1])
                : 0;
            if (minorVersion > otherMinorVersion)
                return true;
            if (minorVersion < otherMinorVersion)
                return false;

            var patchVersion = versionParts.Length > 2
                ? int.Parse(versionParts[2])
                : 0;
            var otherPatchVersion = otherVersionParts.Length > 2
                ? int.Parse(otherVersionParts[2])
                : 0;
            if (patchVersion > otherPatchVersion)
                return true;

            return false;
        }
    }
}