module.exports = {
  preset: 'jest-preset-angular',
  setupFilesAfterEnv: ['<rootDir>/setup-jest.ts'],
  moduleNameMapper: {
    '\\.(css|scss)$': 'identity-obj-proxy',
    '\\.(html)$': '<rootDir>/src/tests/mocks/htmlMock.js'
  },
  testEnvironment: 'jsdom',
  transform: {
    '^.+\\.(ts|mjs|html|js)$': [
      'jest-preset-angular',
      {
        tsconfig: '<rootDir>/tsconfig.spec.json',
        stringifyContentPathRegex: '\\.html$',
      },
    ],
  },
  moduleFileExtensions: ['ts', 'html', 'js', 'json'],
  testMatch: ['**/__tests__/**/*.spec.ts', '**/?(*.)+(spec).ts'],
  collectCoverage: true,
  coverageDirectory: 'coverage',
  reporters: ['default'],
};
