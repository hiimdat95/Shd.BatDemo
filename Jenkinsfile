@Library('s23nbsndimis-dotNet') _

def modl = "${currentBuild.fullProjectName}".tokenize( '/' )
def submodl = "${modl[1]}".tokenize( '-' )
def appRepo = "https://devopsSND@bitbucket.org/synodus/s23nbsndimis.git"

parameters {
    string (
        name: 'BRANCH_NAME',
        defaultValue: 'develop',
        description: 'Branch name of Repository'
    )
}

dotNetWindowsBEPipelineNoWithProfile (
    WORKSPACE: "%WORKSPACE%",
    APP_REPO: appRepo,
    BRANCH_NAME: "${BRANCH_NAME}",
    CREDENTIALS_ID: "bitbucket-devopsSND-https",
    APP_NAME: "s23nbsndimis",
    SRC_PATH: "%WORKSPACE%" + "/src/Host/imis.Web.Mvc",
    SONAR_HOST: "https://ci.aequitas.vn/sonar",
    SONAR_LOGIN: "a81f61c77f4c628ed6ed589546acb42847cf7790",
    RELEASE_DIR: "%WORKSPACE%" + "/src/Host/imis.Web.Mvc/bin/Release/net8.0/publish",
    RELEASE_DIR_01: "%WORKSPACE%" + "/src/Host/imis.Web.Mvc/node_modules",
    //PUBLISH_PROFILE_PATH: "%WORKSPACE%" + "/src/Host/opendata.Web.Mvc/Properties/Staging.pubxml",
    TARGET_SERVER: "administrator@10.0.10.50",
    APP_DIR: "C:\\inetpub\\wwwroot\\imis-dev.aequitas.dev",
    SCP_PROG: "\"C:\\Program Files\\OpenSSH\\scp.exe\"",
    SSH_PROG: "\"C:\\Program Files\\OpenSSH\\ssh.exe\"",
    IIS_SITE: "imis-dev.aequitas.dev",
    APPCMD_PROG: "\"C:\\Windows\\System32\\inetsrv\\appcmd.exe\"",
    SDK_3_1_25: "3.1.25",
    SDK_5_0_17: "5.0.17",
    SDK_6_0_0: "6.0.0",
    SDK_6_0_16: "6.0.16",
    SDK_7_0_11: "7.0.11",
    SDK_8_0_303: "8.0.303"
)