#include "MainWindow.h"
#include "./ui_MainWindow.h"

#include <QDir>
#include <QDirIterator>
#include <QFileDialog>
#include <QStringList>
#include <QStringListModel>
#include <QListWidget>

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::btnOpenRepo_clicked() {
    auto dir = this->selectDirectory();

    this->fillListViewSourceFiles(dir);
    this->fillListViewIncludes();
    this->fillListViewDefines();

}

QString MainWindow::selectDirectory() {
    return QFileDialog::getExistingDirectory(this, tr("select directory"));
}

void MainWindow::fillListViewSourceFiles(QString directory){

    QDirIterator it(
                directory,
                QStringList()
                << "*.h" << "*.hpp" << "*.cc" << "*.cxx" << "*.cpp"
                << "*.H" << "*.HPP" << "*.CC" << "*.CXX" << "*.CPP",
                QDir::Files,
                QDirIterator::Subdirectories);

    QStringList lst;
    while (it.hasNext()) {
        lst << it.next();
    }

    QStringListModel *model = new QStringListModel(this);
    model->setStringList(lst);

    ui->lsvSourceFiles->setModel(model);
}

void MainWindow::fillListViewIncludes(){
    auto model = ui->lsvSourceFiles->model();
    model->rowCount();
    QStringList include_list;
    for(int i = 0; i < model->rowCount(); ++i)
    {
        QModelIndex vIndex = model->index(i, 0);
        QString file_path  = model->data(vIndex).value<QString>();
        QFile file_handle  = QFile(file_path);
        if(file_handle.open(QIODevice::ReadOnly)) {
            while (!file_handle.atEnd()) {
                QByteArray line  = file_handle.readLine();
                QString line_str = QString(line);
                if(line_str.contains('#') && line_str.contains("include") && !line_str.contains("if") && !line_str.contains("&&") && !line_str.contains(")") && !line_str.contains("(")) {
                    if(line_str.contains('<') && line_str.contains('>')) {
                        include_list << line_str;
                    } else {
                        int num_quotes = 0;
                        foreach(QChar c, line_str) {
                            if(c == '\"') {
                                num_quotes += 1;
                            }
                        }
                        // line has # and two quotes
                        if(num_quotes == 2) {
                            include_list << line_str;
                        }
                    }
                }
            }
        }
    }
    QStringListModel *include_model = new QStringListModel(this);
    include_model->setStringList(include_list);
    ui->lsvIncludeHeaders->setModel(include_model);
}

void MainWindow::fillListViewDefines() {

    auto model = ui->lsvSourceFiles->model();
    model->rowCount();

    QStringList include_list;
    for(int i = 0; i < model->rowCount(); ++i)
    {
        QModelIndex vIndex = model->index(i, 0);
        QString file_path = model->data(vIndex).value<QString>();
        QFile file_handle = QFile(file_path);
        if(file_handle.open(QIODevice::ReadOnly)) {
            while (!file_handle.atEnd()) {
                QByteArray line  = file_handle.readLine();
                QString line_str = QString(line);
                if(line_str.contains('#') && line_str.contains("elif") && !line_str.contains("\"")) {
                    include_list << line_str;
                } else if(line_str.contains('#') && line_str.contains("ifdef") && !line_str.contains("\"")) {
                    include_list << line_str;
                } else if(line_str.contains('#') && line_str.contains("ifndef") && !line_str.contains("\"")) {
                    include_list << line_str;
                }
            }
        }
    }

    QStringListModel *define_model = new QStringListModel(this);
    define_model->setStringList(include_list);
    ui->lsvDefines->setModel(define_model);

}
