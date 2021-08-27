#include "IncludeHeaderHandler.h"

IncludeHeaderHandler::IncludeHeaderHandler(QString header_str)
{
    this->header_str = header_str;
}


QString IncludeHeaderHandler::GetHeaderName() {
    return this->header_str
            .replace('#', ' ')
            .replace("include", " ")
            .replace('<', ' ')
            .replace('>', ' ')
            .replace('\"', ' ')
            .remove(' ');
}
