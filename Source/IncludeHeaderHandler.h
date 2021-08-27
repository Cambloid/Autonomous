#ifndef INCLUDEHEADERHANDLER_H
#define INCLUDEHEADERHANDLER_H

#include <QString>

class IncludeHeaderHandler
{

public:
    IncludeHeaderHandler(QString);

private:
    QString GetHeaderName();

private:
    QString header_str = "";

};

#endif // INCLUDEHEADERHANDLER_H
