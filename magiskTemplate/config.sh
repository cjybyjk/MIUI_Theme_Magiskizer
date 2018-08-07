##########################################################################################
#
# Magisk Module Template Config Script
# by topjohnwu
#
##########################################################################################
##########################################################################################
#
# Instructions:
#
# 1. Place your files into system folder (delete the placeholder file)
# 2. Fill in your module's info into module.prop
# 3. Configure the settings in this file (config.sh)
# 4. If you need boot scripts, add them into common/post-fs-data.sh or common/service.sh
# 5. Add your additional or modified system properties into common/system.prop
#
##########################################################################################

##########################################################################################
# Configs
##########################################################################################

# 如果你需要magic mount,请设置成true
AUTOMOUNT=true

# 如果你需要重写system.prop,请设置成true
PROPFILE=false

# 如果你需要post-fs-data脚本,请设置成true
POSTFSDATA=false

# 如果你需要service脚本,请设置成true
LATESTARTSERVICE=false

##########################################################################################
# Installation Message
##########################################################################################

# 这是你安装模块时显示的信息

print_modname() {
  ui_print "********************************"
  ui_print "        MIUI_Theme_Module"
  ui_print "Created by MIUI_Theme_Magiskizer"
  ui_print "********************************"
}

##########################################################################################
# Replace list
##########################################################################################

# 这个列表包含了需要直接替换的文件
# 当确认magic mount不能正常工作时才需要使用这个

# 这是示例
REPLACE="
/system/app/Youtube
/system/priv-app/SystemUI
/system/priv-app/Settings
/system/framework
"

# 将你需要替换的文件放到下面的列表中
# 如果你不需要替换文件,请保持这个状态,千万不要删除这行
REPLACE="
"

##########################################################################################
# Permissions
##########################################################################################

set_permissions() {
  # 只有部分特殊文件需要设置权限
  # 默认的权限适用于大多数情况

  # 这是部分 set_perm 和 set_perm_recursive 函数的示例

  # set_perm_recursive  <dirname>                <owner> <group> <dirpermission> <filepermission> <contexts> (default: u:object_r:system_file:s0)
  # set_perm_recursive  $MODPATH/system/lib       0       0       0755            0644

  # set_perm  <filename>                         <owner> <group> <permission> <contexts> (default: u:object_r:system_file:s0)
  # set_perm  $MODPATH/system/bin/app_process32   0       2000    0755         u:object_r:zygote_exec:s0
  # set_perm  $MODPATH/system/bin/dex2oat         0       2000    0755         u:object_r:dex2oat_exec:s0
  # set_perm  $MODPATH/system/lib/libart.so       0       0       0644

  # 不要删除这一行!
  set_perm_recursive  $MODPATH  0  0  0755  0644
  
}

##########################################################################################
# Custom Functions
##########################################################################################

# This file (config.sh) will be sourced by the main flash script after util_functions.sh
# If you need custom logic, please add them here as functions, and call these functions in
# update-binary. Refrain from adding code directly into update-binary, as it will make it
# difficult for you to migrate your modules to newer template versions.
# Make update-binary as clean as possible, try to only do function calls in it.

# 移动指定的文件
move_files() {
  while read lineinText
	do
    sourceFile='system/media/theme/default/'`echo $lineinText | awk -F ' -> ' '{print \$1}'`
    pathtofile=`echo $lineinText | awk -F ' -> ' '{print \$2}'`
    filepath=${pathtofile%/*}
    if [ -f "$MODPATH/$sourceFile" ]; then
      mkdir -p $MODPATH/$filepath
      mv -f $MODPATH/$sourceFile $MODPATH/$pathtofile
    fi
	done < $INSTALLER/common/list_of_moving_files
}
