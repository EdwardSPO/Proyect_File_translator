module.exports = {
  moduleFileExtensions: ["js", "jsx", "json", "vue", "ts"],
  transform: {
    "^.+\\.vue$": "vue-jest",
    ".+\\.(css|styl|less|sass|scss|svg|png|jpg|ttf|woff|woff2)$":
      "jest-transform-stub",
    "^.+\\.(js|jsx|ts)?$": "<rootDir>/node_modules/babel-jest",
  },
  transformIgnorePatterns: [
    //'/node_modules/',
    "<rootDir>/node_modules/(?!vuetify)",
  ],
  moduleNameMapper: {
    "^@/(.*)$": "<rootDir>/src/$1",
    "\\.(css|less)$": "identity-obj-proxy",
  },
  snapshotSerializers: ["jest-serializer-vue"],
  testMatch: [
    "**/tests/**/*.spec.(js|jsx|ts|tsx)|**/__tests__/*.(js|jsx|ts|tsx)",
  ],
  testURL: "http://localhost/",
  watchPlugins: [
    "jest-watch-typeahead/filename",
    "jest-watch-typeahead/testname",
  ],
  collectCoverage: true,
  collectCoverageFrom: [
    "**/*.{js,vue}",
    "!**/node_modules/**",
    "!**/src/services/**",
    "!**/src/plugins/**",
    "!**/coverage/**",
  ],
};
