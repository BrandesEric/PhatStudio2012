; !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
; To add a localization:
; 1) Add the language to the [Languages] section
; 2) Add localizations to the [Messages] section
; 3) Add localizations to the [CustomMessages] section
; 4) Add License Agreement localization
; !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

[Setup]
; !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
; BEGIN CUSTOMIZATION SECTION: Customize these constants
; !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

; Ensure that you use YOUR OWN APP_ID; DO NOT REUSE THIS ONE
#define APP_ID "{{58534807-17E7-4254-8E2A-AAA932A00321}"

#define APP_NAME "PhatStudio"
#define APP_DESC "PhatStudio - Work Phaster"
#define APP_INFO "For more information about Phat Studio, see the Phat Studio website at\r\nhttp://phatstudio.sourceforge.net/\r\n"
#define APP_ICON "0000010001002020000000001800A80C0000160000002800000020000000400000000100180000000000000C0000000000000000000000000000000000006161B86161B84A4AB04A4AAE4A4AAC4A4AAB4949AA4949A94949A84949A74949A64949A54949A44949A34949A24949A14949A049499F49499E49499E49499C49499C49499B49499B49499949499949499949499949499A49499B6060A46060A46161B86161B84A4AB04A4AAE4A4AAC4A4AAB4949AA4949A94949A84949A74949A64949A54949A44949A34949A24949A14949A049499F49499E49499E49499C49499C49499B49499B49499949499949499949499949499A49499B6060A46060A44A4AB44A4AB43030AB3030A93030A73030A63030A53030A43030A23030A12F2FA02F2F9F2F2F9D2F2F9C2F2F9B2F2F9A2F2F992F2F982F2F972F2F962F2F952F2F942F2F932F2F932F2F922F2F912F2F902F2F902F2F8F2F2F9049499B49499B4A4AB44A4AB43030AA3030A93030A63030A63030A43030A33030A13030A12F2F9F2F2F9E2F2F9C2F2F9C2F2F9A2F2F9A2F2F982F2F972F2F962F2F952F2F942F2F932F2F922F2F922F2F912F2F902F2F8F2F2F8E2F2F8E2F2F8F49499A49499A4A4AB64A4AB63030AD3030AB3030A93030A83030A73030A63030A43030A33030A13030A02F2F9F2F2F9E2F2F9D2F2F9C2F2F9A2F2F992F2F982F2F972F2F962F2F952F2F942F2F932F2F922F2F922F2F902F2F902F2F8F2F2F914949994949994A4AB74A4AB73030AE3030AC3030AA3030A93030A83030A73030A63030A53030A23030A22F2FA02F2FA02F2F9E2F2F9D2F2F9B2F2F9A2F2F992F2F982F2F972F2F962F2F952F2F942F2F932F2F922F2F912F2F902F2F902F2F914949994949994A4AB94A4AB93030B13030AF3030AD3030AC3030AB3030AB4949B04949B14B4BB04B4BAF3030A43030A44747A94848AA4B4BAA4C4CAA2F2F9B2F2F9C4747A24848A44B4BA54C4CA42F2F952F2F942F2F932F2F922F2F912F2F9349499C49499C4A4ABA4A4ABA3030B23030B03030AE3030AD3131AC3232AD4949B14949B24B4BB14B4BAF3030A53030A54747AA4848AB4B4BAB4C4CAA2F2F9C2F2F9C4747A34848A54B4BA54C4CA42F2F962F2F952F2F942F2F932F2F922F2F9349499C49499C4B4BBD4B4BBD3131B53131B33030B13232B13A3AB33B3BB3F9F9FCF9F9FCFCFCFDFCFCFD5050B35050B4F8F8FBF9F9FBFCFCFEFDFDFE5656B05656B0F8F8FBF9F9FBFCFCFEFDFDFE4C4CA64C4CA52F2F962F2F952F2F942F2F9549499E49499E4B4BBE4B4BBE3131B63131B43131B23232B23B3BB43C3CB4F8F8FCF9F9FCFBFBFDFBFBFD4F4FB44F4FB4F7F7FBF8F8FBFCFCFDFCFCFE5555B05555B0F7F7FBF8F8FBFCFCFDFCFCFE4C4CA64C4CA62F2F972F2F962F2F952F2F9649499E49499E4B4BC14B4BC13131B93131B73131B53232B53A3AB63C3CB7F5F5FBF5F5FBF8F8FCF9F9FC4D4DB64D4DB6F2F2F9F3F3FAF9F9FCF9F9FC5252B15252B1F2F2F9F3F3FAF9F9FCF9F9FC4949A74949A72F2F992F2F982F2F972F2F984949A04949A04B4BC24B4BC23131BA3131B83131B63232B63939B73A3AB7F4F4FBF5F5FBF8F8FCF8F8FC4C4CB54C4CB5F1F1F9F2F2F9F8F8FCF9F9FC5151B15151B0F1F1F9F2F2F9F8F8FCF9F9FC4949A74949A62F2F9B2F2F992F2F982F2F994949A14949A14B4BC44B4BC43131BD3131BB3131B93131B83333B73333B74C4CBD4C4CBE4F4FBD4F4FBB3030B23030B14A4AB64B4BB74F4FB75050B63030AA3131A93535A73636A73737A63636A53030A12F2FA02F2F9D2F2F9C2F2F9A2F2F9B4949A34949A34B4BC54B4BC53131BE3131BC3131BA3131B93333B83333B84C4CBD4C4CBE4F4FBD4F4FBB3030B33030B24A4AB64B4BB74F4FB75050B63030AA3131A93535A83535A73636A63636A53030A12F2FA02F2F9E2F2F9D2F2F9B2F2F9C4949A44949A44B4BC74B4BC73131C03131BF3131BD3232BD3A3ABE3B3BBEF8F8FCF8F8FCFBFBFDFBFBFD4F4FBD4F4FBDF6F6FBF7F7FBFBFBFDFCFCFD4B4BB44B4BB33131A93131A83131A63131A53030A33030A23030A030309F2F2F9E2F2F9F4949A64949A64B4BC84B4BC83131C13131BF3131BE3333BE3B3BBF3C3CBFF8F8FCF8F8FCFAFAFDFBFBFD4F4FBE4F4FBEF6F6FBF7F7FBFBFBFDFCFCFD4B4BB64B4BB53030AA3030A83030A63030A53030A43030A33030A13030A02F2F9F2F2FA04949A74949A74C4CCB4C4CCB3131C43131C23131C03333C03B3BC13C3CC2F6F6FCF7F7FCF9F9FDF9F9FD4F4FC04F4FC0F4F4FBF5F5FBFAFAFDFBFBFD4B4BB84B4BB73030AD3030AB3030A93030A83030A73030A63030A43030A33030A23030A34949A94949A94C4CCC4C4CCC3131C53131C33131C13333C13A3AC23B3BC2F6F6FCF6F6FCF9F9FDF9F9FD4F4FC04F4FC0F4F4FBF5F5FBFAFAFDFBFBFD4B4BB84B4BB73030AE3030AC3030AA3030A93030A83030A73030A53030A43030A33030A44949AA4949AA4C4CCF4C4CCF3232C93232C73232C43232C33333C23333C35151C85151C95454C85454C73131BD3333BC3A3ABC3C3CBC3E3EBA3D3DB93232B53131B33030B03030AF3030AD3030AC3030AB3030AA3030A83030A73030A63030A74A4AAD4A4AAD4C4CD04C4CD03232C93232C83232C53232C53333C33333C45151C85151C95454C85454C63131BD3232BC3939BC3B3BBC3D3DBA3B3BB93232B43131B33030B13030B03030AE3030AD3030AC3030AB3030A93030A83030A73030A84A4AAE4A4AAE4C4CD14C4CD13232CC3232CA3232C93333C83B3BC93C3CC9F8F8FDF8F8FDFBFBFDFBFBFD4747C44747C33232BD3333BC3232BA3333B93131B73131B63131B43131B33030B13030B03030AF3030AE3030AC3030AB3030A93030AA4A4AB04A4AB04C4CD14C4CD13232CC3232CB3232CA3434CA3C3CCA3D3DCAF8F8FDF8F8FDFAFAFDFBFBFD4747C54747C43131BE3131BC3131BA3131B93131B83131B73131B53131B43030B23030B13030B03030AF3030AD3030AC3030AA3030AB4A4AB14A4AB14C4CD34C4CD33232CE3232CD3232CC3434CC3C3CCC3D3DCDF6F6FCF7F7FCF9F9FDF9F9FD4747C74747C63131C03131BF3131BD3131BC3131BA3131B93131B83131B73131B53131B43131B33131B23030B03030AF3030AD3030AE4A4AB44A4AB44C4CD34C4CD33232CE3232CD3232CC3333CC3B3BCD3C3CCDF6F6FCF6F6FCF9F9FDF9F9FD4747C84747C73131C13131BF3131BE3131BD3131BB3131BA3131B93131B83131B63131B53131B43131B33030B13030B03030AE3030AF4A4AB54A4AB54C4CD54C4CD53232D03232CF3232CE3232CE3434CC3535CC3B3BCE3D3DCE3E3ECC3D3DCB3434C73232C63131C33131C23131C03131BF3131BE3131BD3131BC3131BB3131B93131B83131B73131B63131B43131B33030B13030B24A4AB74A4AB74C4CD54C4CD53232D03232CF3232CE3232CE3232CD3333CD3A3ACE3B3BCE3D3DCC3C3CCB3333C73232C63131C43131C33131C13131C03131BF3131BE3131BD3131BC3131BA3131B93131B83131B73131B53131B43030B23030B34A4AB84A4AB84C4CD64C4CD63232D13232D03232D03232D03232CF3232CE3333CD3434CD3434CC3434CC3232CA3232C93232C83232C73232C53232C43131C23131C13131BF3131BE3131BD3131BC3131BB3131BA3131B83131B73131B53131B64A4ABB4A4ABB4C4CD64C4CD63232D13232D03232D03232D03232CF3232CF3232CE3232CD3232CC3232CC3232CB3232CA3232C93232C83232C63232C53131C33131C23131C03131BF3131BE3131BD3131BC3131BB3131B93131B83131B63131B74A4ABC4A4ABC4C4CD64C4CD63232D23232D13232D13232D13232D03232D03232CF3232CF3232CE3232CE3232CC3232CC3232CB3232CA3232C93232C83232C63232C53131C33131C23131C13131C03131BE3131BE3131BC3131BB3131B93131BA4B4BBF4B4BBF4C4CD74C4CD73232D33232D23232D23232D23232D13232D13232D03232D03232CF3232CF3232CD3232CD3232CC3232CC3232CA3232CA3232C83232C73131C53131C43131C33131C23131C03131BF3131BE3131BD3131BB3131BC4B4BC04B4BC06262DA6262DA4C4CD74C4CD64C4CD64C4CD64C4CD64C4CD64C4CD54C4CD54C4CD54C4CD44C4CD44C4CD34C4CD24C4CD24C4CD14C4CD04C4CCF4C4CCF4C4CCD4C4CCD4C4CCA4C4CC94B4BC84B4BC84B4BC64B4BC54B4BC34B4BC46161C76161C76262DA6262DA4C4CD74C4CD64C4CD64C4CD64C4CD64C4CD64C4CD54C4CD54C4CD54C4CD44C4CD44C4CD34C4CD24C4CD24C4CD14C4CD04C4CCF4C4CCF4C4CCD4C4CCD4C4CCA4C4CC94B4BC84B4BC84B4BC64B4BC54B4BC34B4BC46161C76161C70000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"
#define APP_VERSION "1.0.0.10"
#define DEFAULT_GROUP_NAME "{cm:MyAddInDefaultGroupName}"
#define HELP_SHORTCUT "{cm:MyAddInHelpFile}"
#define DEST_SUB_DIR "PhatStudio"
#define LICENSE_AGREEMENT_FILE_NAME "LicenseAgreement.rtf"
#define BIN_SRCFILE_DIR "..\bin"
#define SRC_DIR ".."
#define DLL_FILE_NAME_VS2005 "PhatStudio.dll"
#define DLL_FILE_NAME_VS2008 "PhatStudio.dll"
#define DLL_FILE_NAME_VS2010 "PhatStudio.dll"
#define DLL_FILE_NAME_VS2012 "PhatStudio.dll"
#define ADDIN_XML_FILE_NAME "PhatStudio.AddIn"
#define MY_COMPANY_NAME "PhatStudio"
#define MY_COMPANY_WEB_SITE "http://phatstudio.sourceforge.net"
#define OUTPUT_FOLDER_NAME "."
#define OUTPUT_BASE_FILE_NAME "PhatStudio-1.11.setup"
#define SETUP_ICON_FILE_NAME = "PhatStudio.ico"
#define COPYRIGHT_YEAR = "2012"

; Ensure that these values are used for the Connect class
#define CONNECT_CLASS_FULL_NAME_VS_2005 = "PhatStudio.Commands"
#define CONNECT_CLASS_FULL_NAME_VS_2008 = "PhatStudio.Commands"
#define CONNECT_CLASS_FULL_NAME_VS_2010 = "PhatStudio.Commands"
#define CONNECT_CLASS_FULL_NAME_VS_2012 = "PhatStudio.Commands"

; !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
; END CUSTOMIZATION SECTION
; !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

OutputDir={#OUTPUT_FOLDER_NAME}
OutputBaseFilename={#OUTPUT_BASE_FILE_NAME}
AppID={#APP_ID}
VersionInfoVersion={#APP_VERSION}
PrivilegesRequired=admin
MinVersion=0,5.0.2195
AppName={#APP_NAME}
AppVerName={#APP_NAME}
DefaultGroupName={#DEFAULT_GROUP_NAME}
AppPublisher={#MY_COMPANY_NAME}
AppPublisherURL={#MY_COMPANY_WEB_SITE}
AppSupportURL={#MY_COMPANY_WEB_SITE}
AppUpdatesURL={#MY_COMPANY_WEB_SITE}
DefaultDirName={pf}\{#DEST_SUB_DIR}
; LicenseFile={#LICENSE_AGREEMENT_FILE_NAME} ; BUGBUG
Compression=lzma
SolidCompression=true
DisableReadyPage=true
ShowLanguageDialog=no
UninstallLogMode=append
; SetupIconFile={#SETUP_ICON_FILE_NAME} ; BUGBUG
DisableProgramGroupPage=false
VersionInfoCompany={#MY_COMPANY_NAME}
AppCopyright=Copyright © {#COPYRIGHT_YEAR} {#MY_COMPANY_NAME}
AlwaysUsePersonalGroup=false
InternalCompressLevel=ultra
AllowNoIcons=true
LanguageDetectionMethod=locale

[Languages]
; USE ENGLISH AS THE FIRST LANGUAGE!!!
Name: English; MessagesFile: compiler:Default.isl
Name: Spanish; MessagesFile: compiler:Languages\Spanish.isl

[Types]
Name: Custom; Description: Custom; Flags: iscustom

[Files]
Source: {#BIN_SRCFILE_DIR}\{#DLL_FILE_NAME_VS2005}; DestDir: {app}; Flags: ignoreversion; AfterInstall: CreateAddInXMLFileVS2005(); Check: IsVS2005Installed()
Source: {#BIN_SRCFILE_DIR}\{#DLL_FILE_NAME_VS2008}; DestDir: {app}; Flags: ignoreversion; AfterInstall: CreateAddInXMLFileVS2008(); Check: IsVS2008Installed()
Source: {#BIN_SRCFILE_DIR}\{#DLL_FILE_NAME_VS2010}; DestDir: {app}; Flags: ignoreversion; AfterInstall: CreateAddInXMLFileVS2010(); Check: IsVS2010Installed()
Source: {#BIN_SRCFILE_DIR}\{#DLL_FILE_NAME_VS2012}; DestDir: {app}; Flags: ignoreversion; AfterInstall: CreateAddInXMLFileVS2012(); Check: IsVS2012Installed()
Source: {#BIN_SRCFILE_DIR}\en-US\phatstudio.resources.dll; DestDir: {app}\en-US; Flags: ignoreversion
Source: {#SRC_DIR}\license.txt; DestDir: {app}; Flags: ignoreversion

[Icons]
Name: {group}\{cm:MyAddInWebSite}; Filename: http://phatstudio.sourceforge.net
Name: {group}\License; Filename: {app}\license.txt
Name: {group}\{cm:UninstallProgram,{#APP_NAME}}; Filename: {uninstallexe}

[Messages]
English.FinishedLabel=Setup has finished installing [name] on your computer.
Spanish.FinishedLabel=La instalación de [name] en su ordenador ha finalizado.

English.UninstallStatusLabel=The uninstallation can take up to a minute while the commands of the add-in are removed from the Visual Studio and Macros IDEs.
Spanish.UninstallStatusLabel=La desinstalación puede tardar hasta un minuto mientras los comandos del complemento se eliminan de los IDEs de Visual Studio y Macros.

[CustomMessages]
English.MyAddInWebSite={#APP_NAME} Web Site
Spanish.MyAddInWebSite=Sitio web de {#APP_NAME}

English.VSNeedsToBeClosed=Please close Visual Studio before continuing.
Spanish.VSNeedsToBeClosed=Cierre Visual Studio antes de continuar.

English.RegisteringAddIn=Registering the add-in...
Spanish.RegisteringAddIn=Registrando el complemento...

English.MyAddInDefaultGroupName={#APP_NAME} for Visual Studio
Spanish.MyAddInDefaultGroupName={#APP_NAME} para Visual Studio

English.MyAddInHelpFile={#APP_NAME} Help
Spanish.MyAddInHelpFile=Ayuda de {#APP_NAME} (en inglés)

English.VSRequired=Visual Studio Standard Edition or higher is required to install this product (Express editions of Visual Studio don´t support add-ins).
Spanish.VSRequired=Se requiere Visual Studio Standard Edition o superior para instalar este producto (las ediciones Express de Visual Studio no soportan complementos).

[Code]

(***************************************************************************************************)
(* Auxiliar function                                                                               *)
(***************************************************************************************************)
function GetXMLAddInFullFolderName(Param: String): String;
var
   sCommonAppDataFolder: String;
   sResult: String;
begin
   sCommonAppDataFolder := ExpandConstant('{commonappdata}');

   (* Param is the version such as '8.0' or '9.0' *)
   sResult := sCommonAppDataFolder + '\Microsoft\VisualStudio\' + Param + '\Addins\'

   Result := sResult;
end;

(***************************************************************************************************)
(* Auxiliar function                                                                               *)
(***************************************************************************************************)
procedure CreateAddInXMLFile(sVersion: String; sConnectClassFullName: String; sDLLFileName: String);
var
   sLines: TArrayOfString;
   sXMLAddInFullFileName: String;
   sAddInDLLFullFileName: String;
   sInstallationFolder: String;
   sFolder: String;
begin

   (* Compose the full name of the add-in DLL *)
   sInstallationFolder := ExpandConstant('{app}');
   sAddInDLLFullFileName := sInstallationFolder + '\' + sDLLFileName;

   (* Get the folder where to put the .AddIn XML registration file *)
   sFolder := GetXMLAddInFullFolderName(sVersion);

   (* Ensure that the folder is created *)
   CreateDir(sFolder);

   (* Compose the full name of the .AddIn XML registration file *)
   sXMLAddInFullFileName := sFolder + '{#ADDIN_XML_FILE_NAME}';

   (* Create the .AddIn XML registration file *)
   SetArrayLength(sLines,18);

   sLines[0]  := '<?xml version="1.0" encoding="windows-1252" standalone="no"?>';
   sLines[1]  := '<Extensibility xmlns="http://schemas.microsoft.com/AutomationExtensibility">';
   sLines[2]  := '   <HostApplication>';
   sLines[3]  := '      <Name>Microsoft Visual Studio</Name>';
   sLines[4]  := '      <Version>' + sVersion + '</Version>';
   sLines[5]  := '   </HostApplication>';
   sLines[6]  := '   <Addin>';
   sLines[7]  := '      <FriendlyName>{#APP_NAME}</FriendlyName>';
   sLines[8]  := '      <Description>{#APP_DESC}</Description>';
   sLines[9]  := '      <Assembly>' + sAddInDLLFullFileName + '</Assembly>';
   sLines[10] := '      <FullClassName>' + sConnectClassFullName + '</FullClassName>';
   sLines[11] := '      <LoadBehavior>1</LoadBehavior>';
   sLines[12] := '      <CommandPreload>1</CommandPreload>';
   sLines[13] := '      <CommandLineSafe>0</CommandLineSafe>';
   sLines[14] := '		<AboutBoxDetails>{#APP_INFO}</AboutBoxDetails>';
   sLines[15] := '		<AboutIconData>{#APP_ICON}</AboutIconData>';
   sLines[16] := '   </Addin>';
   sLines[17] := '</Extensibility>';

   SaveStringsToFile(sXMLAddInFullFileName, sLines, False);
end;

(***************************************************************************************************)
(* Auxiliar function                                                                               *)
(***************************************************************************************************)
procedure CreateAddInXMLFileVS2005();
begin
   CreateAddInXMLFile('8.0','{#CONNECT_CLASS_FULL_NAME_VS_2005}', '{#DLL_FILE_NAME_VS2005}')
end ;

(***************************************************************************************************)
(* Auxiliar function                                                                               *)
(***************************************************************************************************)
procedure CreateAddInXMLFileVS2008();
begin
   CreateAddInXMLFile('9.0','{#CONNECT_CLASS_FULL_NAME_VS_2008}', '{#DLL_FILE_NAME_VS2008}')
end ;

(***************************************************************************************************)
(* Auxiliar function                                                                               *)
(***************************************************************************************************)
procedure CreateAddInXMLFileVS2010();
begin
   CreateAddInXMLFile('10.0','{#CONNECT_CLASS_FULL_NAME_VS_2010}', '{#DLL_FILE_NAME_VS2010}')
end ;

(***************************************************************************************************)
(* Auxiliar function                                                                               *)
(***************************************************************************************************)
procedure CreateAddInXMLFileVS2012();
begin
   CreateAddInXMLFile('11.0','{#CONNECT_CLASS_FULL_NAME_VS_2012}', '{#DLL_FILE_NAME_VS2012}')
end ;

(***************************************************************************************************)
(* Auxiliar function                                                                               *)
(***************************************************************************************************)
procedure ShowCloseVisualStudioMessage();
var
   sMsg: String;
begin
   sMsg := CustomMessage('VSNeedsToBeClosed');
   MsgBox(sMsg, mbCriticalError, mb_Ok)
end;

(***************************************************************************************************)
(* Auxiliar function                                                                               *)
(***************************************************************************************************)
procedure ShowVisualStudioRequiredMessage();
var
   sMsg: String;
begin
   sMsg := CustomMessage('VSRequired');
   MsgBox(sMsg, mbCriticalError, mb_Ok)
end;

(***************************************************************************************************)
(* Auxiliar function                                                                               *)
(***************************************************************************************************)
function IsVSInstalledByProgID(ProgID: String):Boolean;
begin

   if RegKeyExists(HKCR, ProgID) then
      Result := True
   else
      Result := False

end;

(***************************************************************************************************)
(* Auxiliar function                                                                               *)
(***************************************************************************************************)
function IsVSRunningByProgID(ProgID: String):Boolean;
var
   IDE: Variant;
begin

   try
      IDE := GetActiveOleObject(ProgID);
   except
   end;

   if VarIsEmpty(IDE) then
      Result := False
   else
      Result := True
end;

(***************************************************************************************************)
(* Auxiliar function                                                                               *)
(***************************************************************************************************)
function IsVS2005Installed():Boolean;
begin
   if IsVSInstalledByProgID('VisualStudio.DTE.8.0') then
      Result := True
   else
      Result := False
end;

(***************************************************************************************************)
(* Auxiliar function                                                                               *)
(***************************************************************************************************)
function IsVS2008Installed():Boolean;
begin
   if IsVSInstalledByProgID('VisualStudio.DTE.9.0') then
      Result := True
   else
      Result := False
end;

(***************************************************************************************************)
(* Auxiliar function                                                                               *)
(***************************************************************************************************)
function IsVS2010Installed():Boolean;
begin
   if IsVSInstalledByProgID('VisualStudio.DTE.10.0') then
      Result := True
   else
      Result := False
end;

(***************************************************************************************************)
(* Auxiliar function                                                                               *)
(***************************************************************************************************)
function IsVS2012Installed():Boolean;
begin
   if IsVSInstalledByProgID('VisualStudio.DTE.11.0') then
      Result := True
   else
      Result := False
end;


(***************************************************************************************************)
(* Auxiliar function                                                                               *)
(***************************************************************************************************)
function IsVSInstalled():Boolean;
begin

   if IsVS2005Installed() then
      Result := True
   else if IsVS2008Installed() then
      Result := True
   else if IsVS2010Installed() then
      Result := True
   else if IsVS2012Installed() then
      Result := True
   else
      begin
         Result := False
         ShowVisualStudioRequiredMessage();
      end

end;

(***************************************************************************************************)
(* Auxiliar function                                                                               *)
(***************************************************************************************************)
function IsSomeVSRunning():Boolean;
begin

   if IsVSRunningByProgID('VisualStudio.DTE.8.0') then
      Result := True
   else if IsVSRunningByProgID('VisualStudio.DTE.9.0') then
      Result := True
   else if IsVSRunningByProgID('VisualStudio.DTE.10.0') then
      Result := True
   else if IsVSRunningByProgID('VisualStudio.DTE.11.0') then
      Result := True
   else
      Result := False

end;

(***************************************************************************************************)
(* Auxiliar function                                                                               *)
(***************************************************************************************************)
procedure UnregisterAddInIfInstalled(sVersion: String; sConnectClassFullName: String);
var
   sXMLAddInFullFileName: String;
   sFolder: String;
   sIDEFullFileName: String;
   iResultCode: Integer;
begin

   (* Compose the full name of the .AddIn XML registration file *)
   sFolder := GetXMLAddInFullFolderName(sVersion);
   sXMLAddInFullFileName := sFolder + '{#ADDIN_XML_FILE_NAME}';

   if FileExists(sXMLAddInFullFileName) then
      begin
         (* Delete the .AddIn XML registration file to unregister the add-in *)
         DeleteFile(sXMLAddInFullFileName);

         (* Compose the full name of the Visual Studio IDE *)
         sIDEFullFileName := ExpandConstant('{reg:HKLM\SOFTWARE\Microsoft\VisualStudio\' + sVersion + ',InstallDir}') + 'devenv.exe'

         (* Remove the commands of the IDE *)
         Exec(sIDEFullFileName, '/ResetAddin ' + sConnectClassFullName + ' /command File.Exit', '', SW_HIDE, ewWaitUntilTerminated, iResultCode);

      end

end;


(***************************************************************************************************)
(* InnoSetup event function                                                                        *)
(***************************************************************************************************)
function InitializeSetup(): Boolean;
begin

   if not IsVSInstalled() then
      begin
         Result := False;
      end
   else
      begin
         if IsSomeVSRunning() then
            begin
               ShowCloseVisualStudioMessage()
               Result := False;
            end
         else
            Result := True;
      end

end;

(***************************************************************************************************)
(* InnoSetup event function                                                                        *)
(***************************************************************************************************)
procedure InitializeWizard();
begin
end;

(***************************************************************************************************)
(* InnoSetup event function                                                                        *)
(***************************************************************************************************)
function InitializeUninstall(): Boolean;
begin

   if IsSomeVSRunning() then
      begin
         ShowCloseVisualStudioMessage()
         Result := False;
      end
   else
       begin
         Result := True;
      end
end;

(***************************************************************************************************)
(* InnoSetup event function                                                                        *)
(***************************************************************************************************)
procedure CurUninstallStepChanged(CurUninstallStep: TUninstallStep);
begin
   if CurUninstallStep = usUninstall then
      begin
         UnregisterAddInIfInstalled('8.0', '{#CONNECT_CLASS_FULL_NAME_VS_2005}' );
         UnregisterAddInIfInstalled('9.0', '{#CONNECT_CLASS_FULL_NAME_VS_2008}' );
         UnregisterAddInIfInstalled('10.0', '{#CONNECT_CLASS_FULL_NAME_VS_2010}' );
         UnregisterAddInIfInstalled('11.0', '{#CONNECT_CLASS_FULL_NAME_VS_2012}' );
      end;
end;
