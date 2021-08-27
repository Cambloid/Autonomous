#include "DefineHandler.h"

DefineHandler::DefineHandler(QString raw_str)
{
    this->raw_str = raw_str;
}

QString DefineHandler::GetDefineStr() {
    return this->raw_str
            .replace('#', ' ')
            .replace("ifdef", " ")
            .replace("ifndef", " ")
            .replace("elif", " ")
            .remove(' ');
}
