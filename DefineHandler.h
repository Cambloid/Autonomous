#ifndef DEFINEHANDLER_H
#define DEFINEHANDLER_H

#include <QString>

class DefineHandler
{
public:
    DefineHandler(QString);

    QString GetDefineStr();

private:
    QString raw_str         = "";
    bool isIncludeGuard     = false;
    bool isPlatformSpecific = false; // _WIN32 MACOSX _LINUX_ etc.
    bool isCompilerSpecific = false; // _GNU_
    bool isBuildOption      = false; // USE_X_FEATURE


};

#endif // DEFINEHANDLER_H
