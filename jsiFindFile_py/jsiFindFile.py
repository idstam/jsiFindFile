import os
from _io import open
from builtins import print
from tkinter import *
from tkinter import filedialog
from tkinter.ttk import Treeview


class App:
    def __init__(self):
        root = Tk()
        frame = Frame(root)
        frame.pack(fill=X, expand=1)
        Label(frame, text="Search root:", justify=LEFT).pack(padx=0, pady=5, side=LEFT)
        self.rootFolderText = Text(frame, height=1)
        self.rootFolderText.pack(padx=5, pady=5, side=LEFT, fill=X, expand=1)
        Button(frame, text="...", command=self.openFolder).pack(padx=5, pady=5)

        frame = Frame(root)
        frame.pack(fill=X, expand=1)
        Label(frame, text="Search for:", justify=LEFT).pack(padx=5, pady=5, side=LEFT)
        self.needleText = Text(frame, height=1)
        self.needleText.pack(padx=5, pady=5, fill=X, expand=1, side=LEFT)

        frame = Frame(root)
        frame.pack(fill=X, expand=1)
        Label(frame, text="lots of settings").pack()

        frame = Frame(root)
        frame.pack(fill=X, expand=1)
        Button(frame, text="Search", command=self.search).pack()

        frame = Frame(root)
        frame.pack(fill=BOTH, expand=1)
        tvw = Treeview(frame, columns=("", ""), selectmode="extended")
        tvw.pack(fill=BOTH, expand=1, side=LEFT)
        ysb = Scrollbar(frame, orient=VERTICAL, command=tvw.yview)
        # xsb = Scrollbar(frame, orient=HORIZONTAL, command=tvw.xview)
        # tvw.configure(yscroll=ysb.set, xscroll=xsb.set)
        tvw.configure(yscroll=ysb.set)
        ysb.pack(fill=Y, expand=1)
        # xsb.pack(fill=X, expand=1)

        tvw.heading('#0', text='Name', anchor="w")
        tvw.heading('#1', text='Matches', anchor="w")
        tvw.heading('#2', text='Path', anchor="w")
        tvw.column('#1', width=65)
        self.tree = tvw

        root.mainloop()

    def openFolder(self):
        fname = filedialog.askdirectory()
        self.rootFolderText.insert(INSERT, fname)

    def search(self):
        needle = self.needleText.get("1.0", END).strip()
        folderName = self.rootFolderText.get("1.0", END).strip()
        print("Searching " + folderName + " for " + needle)

        self.walkFolders(folderName)

    def walkFolders(self, rootFolder):
        for path, dirs, files in os.walk(rootFolder):
            for filename in files:
                fullpath = os.path.join(path, filename)
                self.testFile(fullpath)

    def addMatch(self, fileName, matches, path):
        nodeId = self.tree.insert("", "end", "", text=fileName, values=((matches, path)))

    def testFile(self, fullPath):
        matchCount = 0
        needle = self.needleText.get("1.0", END).strip()
        path, fileName = os.path.split(fullPath)

        with open(fullPath) as fp:
            for line in fp:
                try:
                    if needle in line:
                        matchCount = matchCount + 1
                except:
                    pass
        if matchCount > 0:
            self.addMatch(fileName, 4, path)


app = App()
