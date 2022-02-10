#!/usr/bin/env bash
export FOLLEACH_DailyStatSettings=/home/folleach/settings/dailyStatSettings.json
export FOLLEACH_Log4NetConfig=/home/folleach/settings/log4net.config

dotnet DailyStat.dll
