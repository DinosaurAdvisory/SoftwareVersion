function lookupSoftwareWithVersionLaterThan(version){
    var url = `https://localhost:5001/api/software?version=${version}` 

    return $.ajax({
        url: url
    });
}
