namespace indexextract_cs {
    public struct BrowserResult {
        public bool cancel;
        public string file;
        internal BrowserResult(bool cancel, string file) {
            this.cancel = cancel;
            this.file = file;
        }
    }
    public struct WorkData {
        public string[] dataJson;
        public string targetPath;
    }
}